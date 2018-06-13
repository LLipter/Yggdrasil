
#Online Reading Application——Yggdrasil

#Developing Tools:
**Workbench** for creating database
**Visual studio** for creating WinForms
**Crystal Report** for generating reports

# 1.Abstract
 Yggdrasil is a dynamic Online-Reading application working with the network, in which you can search for book, read books, collect books, select chapters, manage books and get report. And our work is based on `C#` for interface, `Java` for handle  request from user, `python` for crawler to collect books and `mysql` for build our Database.
  
  With a strong database of books, you can choose among a variety of books that may interest you. In the database, we set category for every book, and with a foreign key to category itself, it can realize the function of heritance. When searching, the search engine uses fuzzy matching technology, which brings you more convenience and higher efficiency. In the reading part, you can shift to whatever content that you want, no matter which chapter or which part, just do as you like. If you’re absorbed in one single book, then you can add this book to your collection then you can find it quickly in your collection page. If you get the privilege of the administrator, you can add a new book into the database of books, or you can just add a new chapter to one book or delete some chapters from the book. If you have some interest in the detailed information about the book, then you can get the report of the book, from which you can get a lot of detailed information about this book such as the name, the publisher, and some other information.   
  
  **Absorbed in the sea of knowledge, you can have a wonderful time with the Yggdrasil library.**

#2.Introduction
To create a appliaction that can be used by many users, we decide to make our project based on network. In this way, our system has to be construncted very strictly without any bugs. And in order to maintain our database more conveniently. We add administrator account as manager of the whole system. Common users can be signed up in our software and the user information will be sent to the remote server on which our database organized. And then users can log in with their account and password in our application. After loging in, user can search for books by title, and comment books or add books to their collection. All these operations will sent request to the server and our `java servlet` will catch these request and return data or modify data in the Database. Almost all the interactions between users and our system are designed in this way.

We use git to control the version of our project, which make teamwork eaiser. Also, we create a repository on github. There are nearly 200 times of commit and push operation on our project.
Here's the link to our project.
https://github.com/Irran/Yggdrasil

#3. Database Design
Our Database, yggdrasil, have 8 tables in all, including user, author, favorite, comment, book, publisher, book_type and type. 

user and book are connected with author, favorite and comment. 

type inherits from itself.

To solve multi to multi problem, we add book_type table between book and type

The ER diagram is like the following:
![](https://i.imgur.com/UG4tgIt.png)

#3.1 Where's our database
We use a server to deploy our database, which is at www.irran.top. We can login to this database through commend like this
```
mysql -h www.irran.top -u yggdrasil -p
```

#3.2 How to collect data
To get enough book data, I write a crawler by python to collect those data.
https://www.booktxt.net/xiaoshuodaquan/
In this website, there're around 3k books. By the benefits of multi-threading, the crawler can retrieve hundreds of books in just a few minutes.
Here's the main part of my crawler

```python
def main(): 
    start_time = time.time()
    books = getBooks()
    i = 0
    total_size = len(books)
    while i < 100: # 只爬前100本书，总共三千本书，实在是太多了，没必要
        if(threading.activeCount() < 50):
            thd = threading.Thread(target=getBook,args=(books[i],i))
            i += 1
            thd.start()
        time.sleep(1)
    for thd in threading.enumerate():
        if(thd.getName() != threading.currentThread().getName()):
            thd.join()
    stop_time = time.time()
    diff = stop_time - start_time
    print(diff,"seconds")
    print(diff/60,"minutes")
    print(diff/60/60,"hours")


if __name__ == '__main__':
    main()
```    
    
#3.3 How to store the content of books
We didn't store the content of books in database, instead, we store the content in some files, and store the uri location in database using a field called location.
All book contents will be stored under a directory named book. For specific book, there'e filed called chapter_no in our book table, which represents the total chapter number of a book. Books will be stored in a directory with name of its location. And each chapter will be stored in a txt file with chapter number as file name.
Also, every book will have some introduction message stored in a file named info.txt and a cover image stored in a file named cover.jpg within the same directory.
For instance, suppose there a book with following data

```
{
	"location":"qwerty",
	"chapter_no:10
}
```

In this example, the first chapter will be stored in book/qwerty/1.txt. The second chapter will be stored in book/qwerty/2.txt. Book introduction will be stored in book/qwerty/info.txt. Cover image will be stored in book/qwerty/cover.jpg.

#3.4 How to modify book content stored in our server
Client application will issue right formatted post request. I design a few servlet written in JAVA to process those request and modify data accordingly.
These servlet will be deployed in Tomcat8.0 on my server. Here's one of my servlets.

```
	@Override
	public void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		
		try {
			String location = req.getParameter("location");
			String content = req.getParameter("content");
			String path = String.format("%s%s/info.txt", getServletContext().getRealPath("/book/"),location);
			FileWriter fw = new FileWriter(path);
			fw.write(content);
			fw.flush();
			fw.close();
		}catch (Exception e) {
			PrintWriter out = resp.getWriter();
			out.println(e.getMessage());
		}
	}
```

#4 System: Interface and Form

#Create the Interface to show our book info
First up, we need to figure out what functions we can provide with our users in this interface. Certainly the book title, summary, and the chapter information should be included in this interface. What's more, we hope users can read our books by selecting the chapter number. To make our application more powerful and user-friendly, we may as well add the **comment** function in this form, and users should also be able to add the current book to their **personal collection**. In this way, we build our form like this 

![](https://i.imgur.com/VVjoLP4.png)

<font size=4px>And user can leave their comments at the bottom of this interface by clicking the summit button and select a chapter in the `ChapterBox` to read book</font>

![](https://i.imgur.com/WnztIzR.png)

<font size=4px>Since our application **depends on the internet**, we need to check the network environment every moment if users want to make any operation such as click the button in current form. We can create a function to check the network and reuse it in every interface. The function is not very difficult.</font>

###Here is the code:
```C#
 private bool IsInternetAvailable()
        {
            try
            {
                Dns.GetHostEntry("www.baidu.com");
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }
```
So now we can avoid some network problem in our application and complete the function of **Submit** button and **Add to my favorite** button. Both the two button click-function have employed the function we define in our DatabaseUtility file. That is `setFavorite()` and `setComment()` and if the user have add the book to his favorite, the button should be changed to "Remove from favorite" so we also define `removeFavorite()`.

###So our code should be like

```C#
private void CollectButton_Click(object sender, EventArgs e)
        {
            if (!IsFavorite)
            {
                IsFavorite = true;
                CollectButton.Text = "Remove from Collection";
                if (IsInternetAvailable())
                {    
                    int situation;
                    situation = DatabaseUtility.setFavorite(Global.user, currentBook);
                    if (situation == 1)
                    {
                        MessageBox.Show("Add successfully");
                    }
                    else if (situation == -2)
                    {
                        MessageBox.Show("This book has already been in your collection!");
                    }
                }
                else
                {
                    MessageBox.Show("Please check your network");
                }
            }
            else
            {
                IsFavorite = false;
                CollectButton.Text = "Add to My Collection";
                if (IsInternetAvailable())
                {
                    int situation;
                    situation = DatabaseUtility.removeFavorite(Global.user, currentBook);
                    if (situation == 1)
                    {
                        MessageBox.Show("Remove successfully");
                    }
                    else if (situation == -2)
                    {
                        MessageBox.Show("This book has already been removed!");
                    }
                }
                else
                {
                    MessageBox.Show("Please check your network");
                }
            }
        }
```
###And the code for comment submit button is very similar to it


#Create the Interface to read our book
So in the last form we have show our book info and allow user to select a chapter to read it. Then when user click the button `Begin to Read`, they will come to the interface where the chapter contents are shown here. Of course, we need to get the contents from our Database on the remote server by using mysql connection in C#. Since our books are stored in `txt file`, we can just get them by `StreamReader` in C# and show them in the textBox. And this interface should not be too complex, just give a clear look to user, which will make book contents stand out!

###Here is the view of this reading interface

![](https://i.imgur.com/Aig3Meq.png)

Also we need to separate the whole chapter into many pages, and user can click next page or last page to change current page to read as they like. But there is a problem for the txt File here needing us to pay attention to, that is the line feeds. In the **Unix** system we define line feeds character as '\n', However, in the Windows system, it's '\r\n'. And our books are collected by crawler in `python` the sent to our winForm by StreamReader. We need to replace all the '\n' to '\r\n' to make the article changing lines correctly!

### Just one line to solve that problem
```C#
content = content.Replace("\n", "\r\n");
```

#Create the Interface show user's collection
To make it convenient for users to find the books they are interested in. We add a function to collect the books as users' collection. And the collection is just a record between users and books, which is also stored in our Database. Everytime a user log in our application and check his collection books, it will send a request to the remote server and the `Java servlet` we create will handle this request and return the collection books of current user from the our Database. Then our form will show those books for users, and user can just click them to read. On the other hand, if the user haven't chosen any books, we should show them a text info to remind them.

###So the Form can be like:
![](https://i.imgur.com/kDeGQzr.png)
###if user has collect some books, it will show as:
![](https://i.imgur.com/DFhJUH2.png)






