INSERT INTO users(name ,surName ,alias, password ,email ,phoneNumber ,address, avaUrl) VALUES ('Anton','Ivanov','gigs','q65w51ww','Ivanov23@gmail.com','2252525','sovetskaia 22/9','#');
INSERT INTO users(name ,surName ,alias, password ,email ,phoneNumber ,address, avaUrl) VALUES ('Kirill','Pirogov','sub_zero','156651qw','Pirogov43@mail.ru','2262626','pervomaiskaia 11/3','#');
INSERT INTO users(name ,surName ,alias, password ,email ,phoneNumber ,address, avaUrl) VALUES ('Genadiy','Bublilov','redFruit','www65161','Bublilov44@yandex.com','2277227','dneprovskaia 15/6','#');
INSERT INTO users(name ,surName ,alias, password ,email ,phoneNumber ,address, avaUrl) VALUES ('Igor','Stepochkin','bigBang','d651dd15','Stepochkin33@silverDog.com','2282828','zabskaia 19/8','#');
INSERT INTO users(name ,surName ,alias, password ,email ,phoneNumber ,address, avaUrl) VALUES ('Ivan','Mednik','alive','fgbfg156','Mednik3030@wildWest.kz','2292929','neftianikov 23/32','#');

select * from users
INSERT INTO roles(roleName ) VALUES ('user');
INSERT INTO roles(roleName ) VALUES ('admin');
INSERT INTO roles(roleName ) VALUES ('operator');
INSERT INTO roles(roleName ) VALUES ('moderator');
INSERT INTO roles(roleName ) VALUES ('owner');

INSERT INTO userRole(roleName ,userId ) VALUES ('user',1);
INSERT INTO userRole(roleName ,userId ) VALUES ('admin',2);
INSERT INTO userRole(roleName ,userId ) VALUES ('user',2);
INSERT INTO userRole(roleName ,userId ) VALUES ('user',3);
INSERT INTO userRole(roleName ,userId ) VALUES ('user',4);
INSERT INTO userRole(roleName ,userId ) VALUES ('user',5);
INSERT INTO userRole(roleName ,userId ) VALUES ('moderator',5);

INSERT INTO posts(name ,userId ) VALUES ('I walk in forest',1);
INSERT INTO posts(name ,userId ) VALUES ('My favourite birthday moments',2);
INSERT INTO posts(name ,userId ) VALUES ('Heroes party',2);
INSERT INTO posts(name ,userId ) VALUES ('picnic on the roof',3);
INSERT INTO posts(name ,userId ) VALUES ('Great campaign',4);
INSERT INTO posts(name ,userId ) VALUES ('sword fighting',5);
INSERT INTO posts(name ,userId ) VALUES ('all my 23 cats',5);

INSERT INTO albums(name ,private, userId ) VALUES ('I and my family',0,1);
INSERT INTO albums(name ,private, userId ) VALUES ('2008 year',1,2);
INSERT INTO albums(name ,private, userId ) VALUES ('last summer',0,2);
INSERT INTO albums(name ,private, userId ) VALUES ('best moments',0,3);
INSERT INTO albums(name ,private, userId ) VALUES ('my animals',0,4);
INSERT INTO albums(name ,private, userId ) VALUES ('I ride on horseback.',0,5);
INSERT INTO albums(name ,private ,userId ) VALUES ('fireshow',0,5);

INSERT INTO pictures(urlStandart, urlMedium, urlSmall,postId, albumId, userId ) VALUES ('#','#','#',1,1,1);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall,postId, albumId, userId ) VALUES ('#','#','#',2,3,1);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall,postId, albumId, userId ) VALUES ('#','#','#',3,2,2);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall,postId, albumId, userId ) VALUES ('#','#','#',4,5,4);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall,postId, albumId, userId ) VALUES ('#','#','#',5,4,3);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall,postId, albumId, userId ) VALUES ('#','#','#',3,2,2);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall,postId, albumId, userId ) VALUES ('#','#','#',4,5,4);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall, postId, albumId, userId ) VALUES ('#','#','#',4,5,4);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall, albumId, userId ) VALUES ('#','#','#',6,5);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall, albumId, userId ) VALUES ('#','#','#',1,1);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall, albumId, userId ) VALUES ('#','#','#',2,2);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall, albumId, userId ) VALUES ('#','#','#',2,2);
INSERT INTO pictures(urlStandart, urlMedium, urlSmall, albumId, userId ) VALUES ('#','#','#',4,3);


INSERT INTO comments(comment , postId, userId ) VALUES ('cool',1,1);
INSERT INTO comments(comment , albumId, userId ) VALUES ('cool',1,1);
INSERT INTO comments(comment , albumId, userId ) VALUES ('great',3,1);
INSERT INTO comments(comment , albumId, userId ) VALUES ('excellent',2,2);
INSERT INTO comments(comment , pictureId, userId ) VALUES ('ideally',4,4);
INSERT INTO comments(comment , pictureId, userId ) VALUES ('fine',5,3);
INSERT INTO comments(comment , albumId, userId ) VALUES ('perfectly',6,5);
INSERT INTO comments(comment , albumId, userId ) VALUES ('very nice',1,1);
INSERT INTO comments(comment , pictureId, userId ) VALUES ('so good',8,2);
INSERT INTO comments(comment , postId, userId ) VALUES ('u r the best',2,2);
INSERT INTO comments(comment , postId, userId ) VALUES ('amazing',4,3);



