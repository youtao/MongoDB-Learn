#MongoDB

----------

##����֪ʶ

###����

    use demo
	post = {
    	"title":"����",
    	"content":"����1",
    	"date":new Date()
    	}
	db.blog.insert(post)

###��ѯ
    db.blog.find()

    {
	    "_id" : ObjectId("56530b9c122af0106a6c1da9"),
	    "title" : "����",
	    "content" : "����1",
	    "date" : ISODate("2015-11-23T12:50:36.077Z")
    }

###����
    post = db.blog.findOne()
    post.comment = []
    post.title = "����1"
    db.blog.update({title:"����1"},post)

###ɾ��
    db.blog.remove({title:"����1"})
    db.blog.find()

###������������
1. null
2. ����
3. ��ֵ
4. �ַ���
5. ����
6. ������ʽ
7. ����
8. ��Ƕ�ĵ�
9. ����id
10. ����������
11. ����


##����,���º�ɾ���ĵ�

###��������
    db.foo.batchInsert([{"name":"����"},{"name":"����"},{"name":"����"}])

####ɾ��
    db.tester.remove()//����ɾ��
    db.tester.drop()//��ȫɾ��

####����

#####$set�޸���	
    db.tester.update({"name":"����"},{"$set":{"address":"China"}})//����޸ļ�
    db.tester.update({"name":"����"},{"$unset":{"address":1}})//ɾ����

#####$inc�޸���
    db.tester.update(
    {"name":"����"},{"$inc":{"scror":90}})//��ʼ��ʱ����Ϊ90,ÿ������90

#####$push�޸���
    db.tester.update(
    {"name":"����"},{"$push":{"comments":{"name":"����","conment":"���ѽ"}}})

#####$each������
    db.tester.update({"age":0},
    {"$push":{"hourly":{"$each":[355.23,23.34,2342.23423]}}})

#####$slice(����5������),$sort(����)
	db.tester.update(
	{"age":0},
	{"$push":{"hourly":
	        {
	            "$each":[35345.23,233.3423,23342.23423],
	            "$slice":-5,
	            "$sort":{"age":-1}
	        }}})

#####$ne
	db.tester.update(
	{"authors":{"$ne":"Richie"}},
	{"$push":{"authors":"Richie"}})

#####$addToSet
	db.tester.update(
	{"age":0},
	{"$addToSet":{"emails":"123456@qq.com"}})

#####$addToSet��$each
	db.tester.update(
	{"age":0},
	{"$addToSet":
	    {"emails":
	        {"$each":
	            ["123456@qq.com","123456789@qq.com","987654321@qq.com"]}}})


#####$pop(ɾ���������Ԫ��,ÿ��ɾ��һ��)
	db.tester.update({"age":0},{"$pop":{"emails":1}})//��β��ɾ��һ��Ԫ��
	db.tester.update({"age":0},{"$pop":{"emails":-1}})//��ͷ��ɾ��һ��Ԫ��

#####$push(ɾ���������Ԫ��,����ƥ��)
	db.tester.update({"age":0},{"$pull":{"emails":"123456@qq.com"}})//ɾ������������ƥ���Ԫ��

#####��λ������($),�����޸���
	db.tester.update({"comments.name":"����"},{"$set":{"comments.$.name":"����"}})

#####upsert(���Ҳ���age==-1ʱ,����һ��age=-1,name="����"���ĵ�)
	db.tester.update({"age":-1},{"$set":{"name":"����"}},true)
