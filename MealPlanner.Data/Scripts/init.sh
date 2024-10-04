use MealPlannerDb

db.createCollection("ProductCategory");
db.ProductCategory.createIndex({ "Name": 1 });


db.createCollection("Product");
db.Product.createIndex({ "Name": 1 });
db.Product.createIndex({ "CategoryId": 1 });