USE db_library
GO

INSERT INTO publisher
	(PublisherName, [Address], Phone)
	VALUES
	('You''ll Never Read This Classics', '111 No Way Pl, Nuh-Uh TX 00000', '343-343-3433'),
	('Nerd Bibles', '236 Bad Odor Way, NeckBeard AL 56230', '314-159-2653'),
	('Thoughtful Sci-Fi', '5689 Pretentious Geek Rd, Red Pill CA 65850', '555-867-5309'),
	('Junk Books Inc.', '9871 You Know You Like It St, Trash MI 89518', '265-589-5584'),
	('High School Required Reading Inc.', '101 Boring St, Dullsville 38756', '314-159-2653'),
	('Worst of Star Wars Plz', '0504 OMG Star Wars Rd, Lucasville UT 21563', '504-999-9999')
;

INSERT INTO [books]
	(Title, PublisherName)
	VALUES
	('War and Peace', 'You''ll Never Read This Classics'),
	('Song of Solomon', 'You''ll Never Read This Classics'),
	('The Fountainhead', 'You''ll Never Read This Classics'),
	('The Lost Tribe', 'You''ll Never Read This Classics'),
	('The Lord of the Rings: The Fellowship of the Ring', 'Nerd Bibles'),
	('The Lord of the Rings: The Two Towers', 'Nerd Bibles'),
	('The Lord of the Rings: The Return of the King', 'Nerd Bibles'),
	('Don Quixote', 'You''ll Never Read This Classics'),
	('Catch 22', 'Thoughtful Sci-Fi'),
	('1984', 'Thoughtful Sci-Fi'),
	('A Murderous Bunny', 'Junk Books Inc.'),
	('A Mispelled Noun', 'Junk Books Inc.'),
	('Third Person Pronoun', 'Junk Books Inc.'),
	('Little Women', 'High School Required Reading Inc.'),
	('Grapes of Wrath', 'High School Required Reading Inc.'),
	('The Catcher in the Rye', 'High School Required Reading Inc.'),
	('The Scarlet Letter', 'High School Required Reading Inc.'),
	('Star Wars: The Cyrstal Star', 'Worst of Star Wars Plz'),
	('Star Wars: Children of the Jedi', 'Worst of Star Wars Plz'),
	('Star Wars: The Courtship of Princess Leia', 'Worst of Star Wars Plz')
;

INSERT INTO [book_authors]
	(BookID, AuthorName)
	Values
	(1, 'Leo Tolstoy'),
	(2, 'Toni Morrison'),
	(3, 'Ayn Rand'),
	(4, 'Dr. Seuss'),
	(5, 'J.R.R. Tolkien'),
	(6, 'J.R.R. Tolkien'),
	(7, 'J.R.R. Tolkien'),
	(8, 'Miguel de Cervantes'),
	(9, 'Joseph Heller'),
	(10, 'George Orwell'),
	(11, 'Stephen King'),
	(12, 'Stephen King'),
	(13, 'Stephen King'),
	(14, 'Louisa May Alcott'),
	(15, 'John Steinbeck'),
	(16, 'J.D. Salinger'),
	(17, 'Nathaniel Hawthorne'),
	(18, 'Vonda N. McIntyre'),
	(19, 'Barbara Hambly'),
	(20, 'Dave Wolverton')
;

INSERT INTO library_branch
	(BranchName, [Address])
	VALUES
	('Hogwarts', '1302 Leviosa Ln, HOGWARTS HW1A 6HC'),
	('Santa''s Workshop', '1 BRRITSCOLD Rd, North Pole 1000-001'),
	('Central', '100 Boring St, Dullsville 38756'),
	('Sharpstown', '234 Exacto Bvd, Sharpstown 51698')
;

INSERT INTO book_copies
	(BookID, BranchID, Number_Of_Copies)
	VALUES
	(1,  1, 999), /*Hogwarts has magical book multipliers*/
	(2,  1, 999),
	(3,  1, 999),
	(4,  1, 999),
	(5,  1, 999),
	(6,  1, 999),
	(7,  1, 999),
	(8,  1, 999),
	(9,  1, 999),
	(10, 1, 999),
	(11, 1, 2),
	(12, 1, 2),
	(13, 1, 2),
	(14, 1, 2),
	(15, 1, 2),
	(16, 1, 2),
	(17, 1, 2),
	(18, 1, 2),
	(19, 1, 2),
	(20, 1, 2),
	(1,  3, 2),
	(2,  3, 2),
	(3,  3, 2),
	(4,  3, 2),
	(5,  3, 2),
	(6,  3, 2),
	(7,  3, 2),
	(8,  3, 2),
	(9,  3, 2),
	(10, 3, 2),
	(11, 3, 3),
	(12, 3, 4),
	(13, 3, 2),
	(14, 3, 8),
	(15, 3, 6),
	(16, 3, 5),
	(17, 3, 3),
	(18, 3, 5),
	(19, 3, 4),
	(20, 3, 5),
	(1,  2, 2),
	(3,  2, 2),
	(5,  2, 2),
	(7,  2, 2),
	(9,  2, 2),
	(11, 2, 2),
	(13, 2, 2),
	(15, 2, 2),
	(17, 2, 2),
	(19, 2, 2),
	(2,  2, 3),
	(4,  2, 6),
	(6,  2, 2),
	(8,  2, 7),
	(10, 2, 9),
	(12, 2, 4),
	(14, 2, 2),
	(16, 2, 3),
	(18, 2, 3),
	(20, 2, 2),
	(1,  4, 5),
	(3,  4, 5),
	(5,  4, 5),
	(7,  4, 5),
	(9,  4, 5),
	(11, 4, 5),
	(13, 4, 5),
	(15, 4, 5),
	(17, 4, 5),
	(19, 4, 5),
	(2,  4, 2),
	(4,  4, 2),
	(6,  4, 2),
	(8,  4, 2),
	(10, 4, 2),
	(12, 4, 2),
	(14, 4, 2),
	(16, 4, 2),
	(18, 4, 2),
	(20, 4, 2)
;

INSERT INTO borrower
	(Name, [Address], Phone)
	VALUES
	('Harry Potter', '4 Privet Drive, Little Whinging, SURREY', '654-515-5165'),
	('Ronald Weasley', '1 Burrow Ln, Burrow, BURROW', '651-515-5165'),
	('Hermione Granger', '35 No One Cares Ln, Ester, MUGGLETON', '652-515-5165'),
	('Rudolph the Rednosed Reindeer', '5 BRRITSCOLD Rd, North Pole', '100-123-4569'),
	('William "Buddy" Hobbs', '7 BRRITSCOLD Rd, North Pole', '100-565-5892'),
	('Joe Blow', '102 Boring St, Dullsville ', '111-111-1111'),
	('Jane Smith', '103 Boring St, Dullsville', '111-111-1112'),
	('Leeroy Jenkins', '895 LEEROY JENKINS Rd, Yeehaw', '418-658-8895')
;

INSERT INTO book_loans
	(BookID, BranchID, CardNo, DateOut, DateDue)
	VALUES
	(1,  1, 100003, '2018-10-11', '2018-11-07'),
	(2,  2, 100003, '2018-10-11', '2018-11-07'),
	(3,  3, 100003, '2018-10-11', '2018-11-07'),
	(4,  4, 100003, '2018-10-01',  GETDATE()),        /* Used get date so query showing books due today will always have data for instructors */
	(5,  1, 100003, '2018-10-11', '2018-11-07'),
	(6,  2, 100003, '2018-10-11', '2018-11-07'),
	(7,  3, 100003, '2018-10-11', '2018-11-07'),
	(8,  4, 100003, '2018-10-11', '2018-11-07'),
	(9,  1, 100003, '2018-10-11', '2018-11-07'),
	(10, 2, 100003, '2018-10-11', '2018-11-07'),
	(11, 3, 100003, '2018-10-11', '2018-11-07'),
	(12, 4, 100003, '2018-10-01',  GETDATE()),
	(13, 1, 100003, '2018-10-11', '2018-11-07'),
	(14, 2, 100003, '2018-10-11', '2018-11-07'),
	(15, 3, 100003, '2018-10-11', '2018-11-07'),
	(16, 4, 100003, '2018-10-11', '2018-11-07'),
	(17, 1, 100003, '2018-10-11', '2018-11-07'),
	(18, 2, 100003, '2018-10-11', '2018-11-07'),
	(19, 3, 100003, '2018-10-11', '2018-11-07'),
	(20, 4, 100003, '2018-10-01', '2018-10-30'),
	(1,  1, 100005, '2018-10-11',  GETDATE()),
	(2,  2, 100005, '2018-10-11', '2018-11-07'),
	(3,  3, 100005, '2018-10-11',  GETDATE()),
	(4,  4, 100005, '2018-10-01', '2018-10-30'),
	(5,  1, 100005, '2018-10-11', '2018-11-07'),
	(6,  2, 100005, '2018-10-11', '2018-11-07'),
	(7,  3, 100005, '2018-10-11', '2018-11-07'),
	(8,  4, 100005, '2018-10-11',  GETDATE()),
	(9,  1, 100005, '2018-10-11', '2018-11-07'),
	(10, 2, 100005, '2018-10-11', '2018-11-07'),
	(11, 3, 100005, '2018-10-11', '2018-11-07'),
	(12, 4, 100005, '2018-10-01', '2018-10-30'),
	(13, 1, 100005, '2018-10-11', '2018-11-07'),
	(14, 2, 100005, '2018-10-11', '2018-11-07'),
	(15, 3, 100005, '2018-10-11', '2018-11-07'),
	(16, 4, 100005, '2018-10-11',  GETDATE()),
	(17, 1, 100005, '2018-10-11', '2018-11-07'),
	(18, 2, 100005, '2018-10-11', '2018-11-07'),
	(19, 3, 100005, '2018-10-11', '2018-11-07'),
	(20, 4, 100005, '2018-10-01', '2018-10-30'),
	(18, 4, 100008, '2018-10-01', '2018-10-30'),
	(19, 4, 100008, '2018-10-01', '2018-10-30'),
	(20, 4, 100008, '2018-10-01', '2018-10-30'),
	(5,  4, 100008, '2018-10-01', '2018-10-30'),
	(6,  4, 100008, '2018-10-01', '2018-10-30'),
	(7,  4, 100008, '2018-10-01', '2018-10-30'),
	(11, 1, 100001, '2018-10-01', '2018-10-30'),
	(12, 2, 100001, '2018-10-01', '2018-10-30'),
	(13, 4, 100001, '2018-10-01',  GETDATE()),
	(7,  4, 100001, '2018-10-01', '2018-10-30')
;
