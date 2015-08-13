select res.com , res.id as idAdminOrModer from albums,
	(select cm.comment as com, albumId , admn.id from comments cm,
		(select users.id as id from users, userRole ur
		 where users.id = ur.userId and (ur.roleName like '%admin%' or ur.roleName like '%moder%')) admn
	where cm.userId = admn.id and cm.albumId is not null) res ,
	(select users.id as id from users, userRole ur
		where users.id = ur.userId and ur.roleName like '%user%') usr
where albums.userId = usr.id and res.albumId = albums.id


select distinct albumres.pId as IdFountPic from(select pId from 
		(select id as pId, postId, albumId from  pictures
		where  postId is not null and albumId is not null) res, comments
	where res.albumId = comments.albumId) albumres
join (select pId from 
		(select id as pId, postId, albumId from  pictures
		where  postId is not null and albumId is not null) res, comments
	where res.postId = comments.postId) postres 
on albumres.pId = postres.pId


select roleName from userRole,
	(select userId from posts ,(select pId from  (select postId as pId,  count(postId) as ct  from pictures
				 group by postId ) res
				 where res.ct = (select  max(ct) as mx from 
								 (select postId as pId,  count(postId) as ct  from pictures
								 group by postId ) res )) res2
	where id = res2.pId) res3 
where userRole.userId = res3.userId
