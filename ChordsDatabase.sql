CREATE DATABASE MusicChords;

USE MusicChords;

CREATE TABLE Fingerings(
FingeringID INT NOT NULL AUTO_INCREMENT,
ChordName VARCHAR(30) NOT NULL UNIQUE,
StringPositions VARCHAR(30),
Fingering VARCHAR(30),
Difficulty VARCHAR(30),
PRIMARY KEY(FingeringID)
);

CREATE TABLE Chords(
ChordID INT NOT NULL AUTO_INCREMENT,
ChordName VARCHAR(30) NOT NULL UNIQUE,
Notes VARCHAR(30),
ChordRoot VARCHAR(30),
ChordType VARCHAR(30),
ChordBass VARCHAR(30),
FingeringID INT,
PRIMARY KEY(ChordID),
CONSTRAINT FK_Fingerings FOREIGN KEY (FingeringID) REFERENCES Fingerings(FingeringID) ON DELETE CASCADE
);

INSERT INTO Fingerings VALUES(1, 'A', 'X02220', 'XX234X', 'Easy');
INSERT INTO Chords VALUES(1, 'A', 'A,C#,E', 'A', 'Major', 'A', 1);
INSERT INTO Fingerings VALUES(2, 'B', 'X24442', 'X12341', 'Hard');
INSERT INTO Chords VALUES(2, 'B', 'B,D#,F#', 'B', 'Major', 'B', 2);
INSERT INTO Fingerings VALUES(3, 'C', 'X32010', 'X32X1X', 'Intermediate');
INSERT INTO Chords VALUES(3, 'C', 'C,E,G', 'C', 'Major', 'C', 3);
INSERT INTO Fingerings VALUES(4, 'D', 'XX0232', 'XXX132', 'Easy');
INSERT INTO Chords VALUES(4, 'D', 'D,F#,A', 'D', 'Major', 'D', 4);
INSERT INTO Fingerings VALUES(5, 'E', '022100', 'X231XX', 'Easy');
INSERT INTO Chords VALUES(5, 'E', 'E,G#,B', 'E', 'Major', 'E', 5);
INSERT INTO Fingerings VALUES(6, 'F', '133211', '134211', 'Hard');
INSERT INTO Chords VALUES(6, 'F', 'F,A,C', 'F', 'Major', 'F', 6);
INSERT INTO Fingerings VALUES(7, 'G', '320033', '21XX34', 'Intermediate');
INSERT INTO Chords VALUES(7, 'G', 'G,B,D', 'G', 'Major', 'G', 7);

INSERT INTO Fingerings VALUES(8, 'Am', 'X02210', 'XX231X', 'Easy');
INSERT INTO Chords VALUES(8, 'Am', 'A,C,E', 'A', 'Minor', 'A', 8);
INSERT INTO Fingerings VALUES(9, 'Bm', 'X24432', 'X13421', 'Hard');
INSERT INTO Chords VALUES(9, 'Bm', 'B,D,F#', 'B', 'Minor', 'B', 9);
INSERT INTO Fingerings VALUES(10, 'Cm', 'X35543', 'X13421', 'Hard');
INSERT INTO Chords VALUES(10, 'Cm', 'C,Eb,G', 'C', 'Minor', 'C', 10);
INSERT INTO Fingerings VALUES(11, 'Dm', 'XX0231', 'XXX231', 'Easy');
INSERT INTO Chords VALUES(11, 'Dm', 'D,F,A', 'D', 'Minor', 'D', 11);
INSERT INTO Fingerings VALUES(12, 'Em', '022000', 'X23XXX', 'Easy');
INSERT INTO Chords VALUES(12, 'Em', 'E,G,B', 'E', 'Minor', 'E', 12);
INSERT INTO Fingerings VALUES(13, 'Fm', '133111', '134111', 'Hard');
INSERT INTO Chords VALUES(13, 'Fm', 'F,Ab,C', 'F', 'Minor', 'F', 13);
INSERT INTO Fingerings VALUES(14, 'Gm', '355333', '134111', 'Hard');
INSERT INTO Chords VALUES(14, 'Gm', 'G,Bb,D', 'G', 'Minor', 'G', 14);

SELECT * FROM Chords;
SELECT * FROM Fingerings;