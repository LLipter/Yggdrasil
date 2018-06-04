import urllib.request
import ssl
import re
import os
import time
import threading

ssl._create_default_https_context = ssl._create_unverified_context
base = 'https://www.booktxt.net'

def getHtml(url):
    html = urllib.request.urlopen(url).read().decode('gbk')
    return html

def getCover(img_url,location):
    urllib.request.urlretrieve(img_url,location)

def getInfo(html):
    pattern_info = '<meta property="og:description" content=".+?"/>'
    res = re.compile(pattern_info).findall(html)[0]
    res = res[41:-3]
    res = res.replace('&nbsp;',' ')
    return res

def write(content,location,mode):
    with open(location,mode,encoding='utf-8') as file:
        file.write(content)

def getChapter(html,res_url):
    html = html[html.find('正文'):]
    pattern_chapter = '<dd><a href=".+?">.+?</a></dd>'
    res = re.compile(pattern_chapter).findall(html)
    for i in range(len(res)):
        chapter = res[i]
        chapter = chapter[13:][:-9]
        index = chapter.find('"')
        chapter_url = chapter[:index]
        chapter_url = base + chapter_url
        # index = chapter.find(' ')
        # chapter_title = chapter[index+1:]
        # print(chapter_url,chapter_title)
        passage = getChapterContent(chapter_url)
        write(passage,'book/' + res_url + '/' + str(i+1) + '.txt','w')
        time.sleep(1)
    return len(res)
    # print(html)

def getChapterContent(chapter_url):
    html = getHtml(chapter_url)
    html = html[html.find('div id="content">'):html.find('<script>read3();</script>')-12]
    # print(html)
    pattern_chapter_content = '&nbsp;&nbsp;&nbsp;&nbsp;.+'
    res = re.compile(pattern_chapter_content).findall(html)
    paragraphs = ''
    for paragraph in res:
        paragraph = paragraph[24:]
        paragraph = paragraph.replace('<br />','')
        # print(paragraph)
        paragraphs += '    ' + paragraph + '\n'
    return paragraphs
    

def getBooks():
    url = base + "/xiaoshuodaquan"
    html = getHtml(url)
    # print(html)

    pattern_title = '<li><a href=".+?">.+?</a></li>'
    res = re.compile(pattern_title).findall(html)
    res = res[10:]
    size = len(res)
    books = []
    for i in range(size):
        url_title = res[i]
        url_title = url_title[13:][:-9]
        index = url_title.find('"')

        url = url_title[:index-1]
        res_url = url[url.rfind('/')+1:]
        title = url_title[index+2:]

        books.append([url,res_url,title])
    return books


def getBook(book,index):
    url = book[0]
    res_url = book[1]
    title = book[2]
    print(index,title)

    os.mkdir('book/' + res_url)
    img_url = 'https://www.booktxt.net/files/article/image/' + res_url[0:1] + '/' + res_url[-4:] + '/' + res_url[-4:] + 's.jpg'
    getCover(img_url,'book/'+res_url+'/cover.jpg')

    subhtml = getHtml(url)
    info = getInfo(subhtml)
    write(info,'book/' + res_url + '/info.txt','w')
    chapter_no = getChapter(subhtml,res_url)

    sqlstr = 'INSERT INTO book(book_name,location,chapter_no) VALUES("' + title + '","' + res_url + '",' + str(chapter_no) + ');\n'
    write(sqlstr,'book.sql','a')



def main(): 
    start_time = time.time()
    books = getBooks()
    i = 0
    total_size = len(books)
    lock = threading.Lock()
    while i < total_size:
        if(threading.activeCount() < 50):
            lock.acquire()
            try:
                thd = threading.Thread(target=getBook,args=(books[i],i))
                i += 1
                thd.start()
            finally:
                lock.release()
        time.sleep(1)
    for thd in threading.enumerate():
        thd.join()
    stop_time = time.time()
    diff = stop_time - start_time
    print(diff,"seconds")
    print(diff/60,"minutes")
    print(diff/60/60,"hours")


if __name__ == '__main__':
    main()