CREATE table users(id integer primary key not null identity (1, 1),
				    name nvarchar(35) not null,
				    surName nvarchar(35) not null,
					alias nvarchar(35) not null,
					password nvarchar(25) not null,
				    email nvarchar(50) not null unique,
					phoneNumber nvarchar(25) null,
					address nvarchar(100)  null ,
					avaUrl nvarchar(300) not null,
					isRemoved bit not null default 0,
					created datetime not null default GetDate() );

CREATE table roles(roleName  nvarchar(35) primary key not null );

CREATE table userRole(id  integer primary key not null identity (1, 1),
					roleName nvarchar(35) not null,
					userId integer not null,
							  foreign key (userId) references users (id),
							  foreign key (roleName) references roles (roleName));

CREATE table posts(id integer primary key not null identity (1, 1),
				    name nvarchar(35) not null,
					created datetime not null default GetDate(),
					modified datetime null default 0,
					likes integer null default 0,
				    userId integer not null,
							  foreign key (userId) references users (id));

CREATE table albums(id integer primary key not null identity (1, 1),
				    name nvarchar(35) not null,
					created datetime not null default GetDate(),
					modified datetime  null default 0,
					likes integer  null default 0,
					private bit not null,
				    userId integer not null,
							  foreign key (userId) references users (id));

CREATE table pictures(id integer primary key not null identity (1, 1),
				    urlStandart nvarchar(300) not null,
					urlMedium nvarchar(300) not null,
					urlSmall nvarchar(300) not null,
					likes integer  null default 0,
					postId integer null,
				    albumId integer not null,
					userId integer not null,
							  foreign key (postId) references posts (id),
							  foreign key (albumId) references albums (id),
							  foreign key (userId) references users (id));

CREATE table comments(id integer primary key not null identity (1, 1),
				    comment nvarchar(1000) not null,
					created datetime not null default GetDate(),
					modified datetime null default 0,
					postId integer null,
				    albumId integer null,
					pictureId integer null,
					userId integer not null,
							  foreign key (postId) references posts (id),
							  foreign key (albumId) references albums (id),
							  foreign key (pictureId) references pictures (id),
							  foreign key (userId) references users (id));

