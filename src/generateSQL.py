


with open('book_type.sql','w') as file:
    for i in range(6,106):
        sqlstr = 'INSERT INTO book_type(book_id,type_id) VALUES(' + str(i) + ',' + str(3) + ');\n'
        file.write(sqlstr)
    for i in range(6,106):
        sqlstr = 'INSERT INTO book_type(book_id,type_id) VALUES(' + str(i) + ',' + str(4) + ');\n'
        file.write(sqlstr)

