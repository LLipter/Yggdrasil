CREATE DATABASE yggdrasil;

USE yggdrasil;

CREATE TABLE user(
	user_id INT auto_increment,
	user_name VARCHAR(50) UNIQUE NOT NULL,
	passwd VARCHAR(50) NOT NULL,
	nick_name VARCHAR(50),
	privilege INT DEFAULT 0, -- 0 means no privilege
	register_date DATETIME DEFAULT NOW(),
	PRIMARY KEY(user_id)
)default charset=utf8;

INSERT INTO user(user_name,passwd,privilege) VALUES('yggdrasil','admin',10);
INSERT INTO user(user_name,passwd) VALUES('test','123456');

CREATE TABLE publisher(
	publisher_id INT auto_increment,
	publisher_name VARCHAR(50),
	PRIMARY KEY(publisher_id)
)default charset=utf8;

INSERT INTO publisher(publisher_name) VALUES('人民文学出版社');
INSERT INTO publisher(publisher_name) VALUES('机械工业出版社');
INSERT INTO publisher(publisher_name) VALUES('武汉大学出版社');
INSERT INTO publisher(publisher_name) VALUES('LLipter网文出版社');


CREATE TABLE book(
	book_id INT auto_increment,
	book_name VARCHAR(100) NOT NULL,
	location VARCHAR(100), -- location
	book_status INT DEFAULT 1, -- 1 means available, 0 means not
	publisher_id INT,
	chapter_no INT DEFAULT 0,
	create_date DATETIME DEFAULT NOW(),
	modify_date DATETIME DEFAULT NOW(),
	PRIMARY KEY(book_id),
	FOREIGN KEY(publisher_id) REFERENCES publisher(publisher_id)
)default charset=utf8;

INSERT INTO book(book_name,location,chapter_no) VALUES('斗破苍穹','dpcqxdhv7db5vt1revrsi1',5);
INSERT INTO book(book_name) VALUES('C++ How to Programming');
UPDATE book SET location = 'cpphtp' WHERE book_name = 'C++ How to Programming';
INSERT INTO book(book_name,location,chapter_no) VALUES('永夜君王','yyjw12315s4fe87g98f4dw',5);
INSERT INTO book(book_name,location,chapter_no) VALUES('斗罗大陆','dldl',5);
INSERT INTO book(book_name,location,chapter_no) VALUES('斗罗大陆2','dldl2',5);
UPDATE book SET publisher_id = 6 WHERE book_id > 5;


CREATE TABLE author(
	user_id INT,
	book_id INT,
	PRIMARY KEY(user_id,book_id),
	FOREIGN KEY(user_id) REFERENCES user(user_id),
	FOREIGN KEY(book_id) REFERENCES book(book_id)
)default charset=utf8;

INSERT INTO author(user_id,book_id) VALUES(1,1);
INSERT INTO author(user_id,book_id) VALUES(1,2);

CREATE TABLE type(
	type_id INT auto_increment,
	ptype_id INT,
	type_name VARCHAR(100) NOT NULL,
	PRIMARY KEY(type_id),
	FOREIGN KEY(ptype_id) REFERENCES type(type_id)
)default charset=utf8;

INSERT INTO type(type_name) VALUES('计算机');
INSERT INTO type(type_name,ptype_id) VALUES('编程语言',1);
INSERT INTO type(type_name) VALUES('小说');
INSERT INTO type(type_name,ptype_id) VALUES('玄幻小说',3);

CREATE TABLE book_type(
	book_id INT,
	type_id INT,
	PRIMARY KEY(book_id,type_id),
	FOREIGN KEY(book_id) REFERENCES book(book_id),
	FOREIGN KEY(type_id) REFERENCES type(type_id)
)default charset=utf8;

INSERT INTO book_type(book_id,type_id) VALUES(1,4);
INSERT INTO book_type(book_id,type_id) VALUES(1,3);
INSERT INTO book_type(book_id,type_id) VALUES(2,2);
INSERT INTO book_type(book_id,type_id) VALUES(2,1);


CREATE TABLE comment(
	comment_id INT auto_increment,
	book_id INT NOT NULL,
	user_id INT NOT NULL,
	content VARCHAR(500) NOT NULL,
	create_date DATETIME DEFAULT NOW(),
	PRIMARY KEY(comment_id),
	FOREIGN KEY(book_id) REFERENCES book(book_id),
	FOREIGN KEY(user_id) REFERENCES user(user_id)
)default charset=utf8;

INSERT INTO comment(book_id,user_id,content) VALUES(1,1,'这书我吹爆');


CREATE TABLE favorite(
	book_id INT NOT NULL,
	user_id INT NOT NULL,
	PRIMARY KEY(book_id,user_id)
)default charset=utf8;

INSERT INTO favorite(book_id,user_id) VALUES(1,1);

ALTER TABLE favorite ADD FOREIGN KEY user_FK(user_id) references user(user_id);
ALTER TABLE favorite ADD FOREIGN KEY book_FK(book_id) references book(book_id);
