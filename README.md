## API Docs

@baseUrl = http://localhost:5133/swagger

### Get all Todo Items
GET {{baseUrl}}/api/TodoItems
Accept: application/json

### Get a specific Todo Item
GET {{baseUrl}}/api/TodoItems/1
Accept: application/json

### Create a new Todo Item
POST {{baseUrl}}/api/TodoItems
Content-Type: application/json

{
  "title": "Buy groceries",
  "isDone": false
}

### Update a Todo Item
PUT {{baseUrl}}/api/TodoItems/1
Content-Type: application/json

{
  "id": 1,
  "title": "Buy groceries",
  "isDone": true
}

### Delete a Todo Item
DELETE {{baseUrl}}/api/TodoItems/1


### Notes
    
CreateScope() để lấy ra dịch vụ AppDbContext.
Database.Migrate() sẽ:
    * Tự kiểm tra các migration có trong project.
    * Nếu database chưa update, nó tự động apply luôn.
    * Nếu database đã ok rồi thì cũng không sao, app cứ chạy bình thường


### SQL syntax
