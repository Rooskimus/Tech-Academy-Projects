USE db_zoo

/* Drill 1 */
SELECT * FROM tbl_habitat

/* Drill 2 */
SELECT species_name FROM tbl_species WHERE species_order = 3

/* Drill 3 */
SELECT nutrition_type FROM tbl_nutrition WHERE nutrition_cost <= 600

/* Drill 4 */
SELECT species_name FROM tbl_species WHERE species_nutrition
	BETWEEN 2202
	AND 2206

/* Drill 5 */
SELECT a1.species_name AS 'Species Name:', a2.nutrition_type AS 'Nutrtion Type:'
FROM tbl_species a1
	INNER JOIN tbl_nutrition a2 ON a1.species_nutrition = a2.nutrition_id

/* Drill 6 */
SELECT a1.species_name, a3.specialist_fname, a3.specialist_lname, a3.specialist_contact
FROM tbl_species a1
RIGHT JOIN tbl_care a2 ON a1.species_care = a2.care_id
RIGHT JOIN tbl_specialist a3 ON a2.care_specialist = a3.specialist_id
WHERE a1.species_name = 'penguin'

/* Drill 7 */

CREATE DATABASE db_drill
GO
USE db_drill
GO

CREATE TABLE Starships(
	ship_id INT PRIMARY KEY NOT NULL IDENTITY,
	ship_name VARCHAR(50) NOT NULL,
	ship_class VARCHAR(50) NOT NULL
	)
CREATE TABLE Starship_Class(
	class_id INT PRIMARY KEY NOT NULL IDENTITY(1000, 100),
	class_name VARCHAR(50)
	)
INSERT INTO Starships
	(ship_name, ship_class)
	VALUES
	('X-Wing', 1000),
	('Y-Wing', 1000),
	('Star Destroyer', 1200),
	('MC80 Home One', 1200),
	('YT-1300', 1100),
	('VCX-100', 1100),
	('YT-2400', 1100)
;

INSERT INTO Starship_Class
	(class_name)
	VALUES
	('Starfighter'),
	('Light Freighter'),
	('Captial Ship')
;

SELECT a1.ship_name, a2.class_name
FROM Starships a1
	INNER JOIN Starship_Class a2 ON a1.ship_class = a2.class_id
WHERE a2.class_name = 'Starfighter'