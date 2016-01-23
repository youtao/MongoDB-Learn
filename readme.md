#MongoDB

----------

##基本知识

###创建

    use demo
	post = {
    	"title":"标题",
    	"content":"内容1",
    	"date":new Date()
    	}
	db.blog.insert(post)

###查询
    db.blog.find()

    {
	    "_id" : ObjectId("56530b9c122af0106a6c1da9"),
	    "title" : "标题",
	    "content" : "内容1",
	    "date" : ISODate("2015-11-23T12:50:36.077Z")
    }

###更新
    post = db.blog.findOne()
    post.comment = []
    post.title = "标题1"
    db.blog.update({title:"标题1"},post)

###删除
    db.blog.remove({title:"标题1"})
    db.blog.find()

###基本数据类型
1. null
2. 布尔
3. 数值
4. 字符串
5. 日期
6. 正则表达式
7. 数组
8. 内嵌文档
9. 对象id
10. 二进制数据
11. 代码


##创建,更新和删除文档

###批量插入
    db.foo.batchInsert([{"name":"张三"},{"name":"李四"},{"name":"王五"}])

####删除
    db.tester.remove()//条件删除
    db.tester.drop()//完全删除

####更新

#####$set修改器	
    db.tester.update({"name":"张三"},{"$set":{"address":"China"}})//添加修改键
    db.tester.update({"name":"张三"},{"$unset":{"address":1}})//删除键

#####$inc修改器
    db.tester.update(
    {"name":"张三"},{"$inc":{"scror":90}})//初始化时分数为90,每次增加90

#####$push修改器
    db.tester.update(
    {"name":"张三"},{"$push":{"comments":{"name":"李四","conment":"你好呀"}}})

#####$each操作符
    db.tester.update({"age":0},
    {"$push":{"hourly":{"$each":[355.23,23.34,2342.23423]}}})

#####$slice(限制5条数据),$sort(排序)
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

#####$addToSet与$each
	db.tester.update(
	{"age":0},
	{"$addToSet":
	    {"emails":
	        {"$each":
	            ["123456@qq.com","123456789@qq.com","987654321@qq.com"]}}})


#####$pop(删除集合里的元素,每次删除一个)
	db.tester.update({"age":0},{"$pop":{"emails":1}})//从尾部删除一个元素
	db.tester.update({"age":0},{"$pop":{"emails":-1}})//从头部删除一个元素

#####$push(删除集合里的元素,所有匹配)
	db.tester.update({"age":0},{"$pull":{"emails":"123456@qq.com"}})//删除集合中所有匹配的元素

#####定位操作符($),数组修改器
	db.tester.update({"comments.name":"李四"},{"$set":{"comments.$.name":"张三"}})

#####upsert(当找不到age==-1时,创建一个age=-1,name="张三"的文档)
	db.tester.update({"age":-1},{"$set":{"name":"张三"}},true)
