// Switch to the database (this will create it if it doesn't exist)
db = db.getSiblingDB('MealPlannerDb');

db.createCollection("ProductCategory");

db.ProductCategory.createIndex({ "Name": 1 });


db.createCollection("Product");
db.Product.createIndex({ "Name": 1 });
db.Product.createIndex({ "CategoryId": 1 });

db.createCollection("MyProduct");

db.createCollection("MyRecipe");