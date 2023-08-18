CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE recipes(
  id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
  title VARCHAR(100) NOT NULL,
  instructions VARCHAR(650) NOT NULL,
  img VARCHAR(400) NOT NULL,
  category VARCHAR(300),
  creatorId VARCHAR(255),
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE ingredients(
  id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
  name VARCHAR(100) NOT NULL,
  quantity VARCHAR(150) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY(recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE favorites (
  id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
  accountId VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

DROP TABLE recipes;
DROP TABLE ingredients;
DROP TABLE favorites;