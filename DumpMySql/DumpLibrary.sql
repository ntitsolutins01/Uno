-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: library
-- ------------------------------------------------------
-- Server version	8.0.43

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('00000000000000_InitialCreate','8.0.7'),('20251008031632_NtitSolutionsCreateBook','8.0.7'),('20251008033742_NtitSolutionsExcludeTodos','8.0.7'),('20251008052634_NtitSolutionsCreateBookRental','8.0.7'),('20251216172609_NtitSolutionsCreateGenre','8.0.7');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL,
  `RoleId` varchar(450) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
INSERT INTO `aspnetroleclaims` VALUES (1,'5bdf214d-30a9-4d1a-9412-73c5aa391291','Book','Create,Read,Update,Delete');
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(450) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `ConcurrencyStamp` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('5bdf214d-30a9-4d1a-9412-73c5aa391291','Administrator','ADMINISTRATOR','092a84e2-c206-4627-bddd-0015feca9b10');
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL,
  `UserId` varchar(450) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ProviderKey` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(450) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(450) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `RoleId` varchar(450) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('d3743b52-1ace-49dc-a016-d063b25e4af3','5bdf214d-30a9-4d1a-9412-73c5aa391291'),('d64d97c8-f371-4e2f-8fd2-57f90f4e6946','5bdf214d-30a9-4d1a-9412-73c5aa391291');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(450) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('79aec67e-27db-40fb-9290-a3bf8dda9a70','admin@ntitsolutions.com','ADMIN@NTITSOLUTIONS.COM','admin@ntitsolutions.com','ADMIN@NTITSOLUTIONS.COM',_binary '','AQAAAAIAAYagAAAAEAvhWDakncLjI5vf9u54DNKyWMLUGEp1QcQxOK3svi0LiUMriYRbvYxFLcm/zBpgfg==','FGD47V77S3ZRQGBGB57VKMQVSN5OIES3','3e6c1cae-7e81-45cb-a5ec-6494dd014b2e',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('d3743b52-1ace-49dc-a016-d063b25e4af3','administrator@uno.com','ADMINISTRATOR@UNO.COM','administrator@uno.com','ADMINISTRATOR@UNO.COM',_binary '\0','AQAAAAIAAYagAAAAEAvhWDakncLjI5vf9u54DNKyWMLUGEp1QcQxOK3svi0LiUMriYRbvYxFLcm/zBpgfg==','FGD47V77S3ZRQGBGB57VKMQVSN5OIES3','3e6c1cae-7e81-45cb-a5ec-6494dd014b2e',NULL,_binary '\0',_binary '\0',NULL,_binary '',1),('d64d97c8-f371-4e2f-8fd2-57f90f4e6946','ntitsolutions01@gmail.com','NTITSOLUTIONS01@GMAIL.COM','ntitsolutions01@gmail.com','NTITSOLUTIONS01@GMAIL.COM',_binary '','AQAAAAIAAYagAAAAEAvhWDakncLjI5vf9u54DNKyWMLUGEp1QcQxOK3svi0LiUMriYRbvYxFLcm/zBpgfg==','FGD47V77S3ZRQGBGB57VKMQVSN5OIES3','1fd55455-9475-4cf5-aac4-f6e90627eaa1',NULL,_binary '\0',_binary '\0',NULL,_binary '',0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(450) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `books` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(200) NOT NULL,
  `Author` varchar(100) NOT NULL,
  `Description` varchar(500) NOT NULL,
  `Genre` varchar(50) NOT NULL,
  `Language_Code` longtext NOT NULL,
  `Created` datetime(6) NOT NULL,
  `CreatedBy` longtext,
  `LastModified` datetime(6) NOT NULL,
  `LastModifiedBy` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (1,'My Man Jeeves','P.G. Wodehouse','These days not many of us have butlers (servants hired to care for you and your house) but whenever people talk about a butler, his name sometimes comes up as Jeeves. That name comes from Wodehouse’s series of books featuring the perfect butler Jeeves, and the many humorous adventures he and his employer had.','COMEDY','En','2025-10-08 00:46:19.410286','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 00:46:19.410666','d64d97c8-f371-4e2f-8fd2-57f90f4e6946'),(4,'The Story of Doctor Dolittle','Hugh Lofting','Doctor Dolittle loves animals. He loves them so much that when his many pets scare away his human patients, he learns how to talk to animals and becomes a veterinarian instead. He then travels the world to help animals with his unique ability to speak their language.','COMEDY','En','2025-10-08 14:29:04.236859','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 14:29:04.236974','d64d97c8-f371-4e2f-8fd2-57f90f4e6946'),(6,' The Picture of Dorian Gray','Oscar Wilde','What if you could stay young forever? Dorian Gray makes a deal to stay young forever—while a painted portrait of him shows all the signs of aging.\r\n\r\nOf course, it turns out this deal he made might not have been such a good idea after all…','FICTION','En','2025-10-08 16:27:57.341639','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 16:27:57.341642','d64d97c8-f371-4e2f-8fd2-57f90f4e6946'),(7,'Dom Casmurro','Machado de Assis','Um romance de realismo que explora a complexidade do ciúme e das relações humanas, narrado por Bentinho.222','ROMANCE','Pt','2025-10-08 20:25:04.320516','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 20:26:10.484445','d64d97c8-f371-4e2f-8fd2-57f90f4e6946'),(12,'Os Lusíadas','Luís Vaz de Camões','Uma epopeia que narra a jornada de Vasco da Gama e celebra a história e cultura de Portugal.','ROMANCE','Pt','2025-10-08 20:45:24.368667','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 20:45:24.368669','d64d97c8-f371-4e2f-8fd2-57f90f4e6946'),(14,'teste','teste','aluguel de livro','FICTION','Pt','2025-12-16 13:50:33.666798','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-12-16 13:50:33.666807','d64d97c8-f371-4e2f-8fd2-57f90f4e6946');
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `booksrental`
--

DROP TABLE IF EXISTS `booksrental`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `booksrental` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BookId` int NOT NULL,
  `UserId` varchar(450) NOT NULL,
  `RentalDate` datetime(6) DEFAULT NULL,
  `ReturnDate` datetime(6) DEFAULT NULL,
  `Created` datetime(6) NOT NULL,
  `CreatedBy` longtext,
  `LastModified` datetime(6) NOT NULL,
  `LastModifiedBy` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_BooksRental_BookId` (`BookId`),
  CONSTRAINT `FK_BooksRental_Books_BookId` FOREIGN KEY (`BookId`) REFERENCES `books` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `booksrental`
--

LOCK TABLES `booksrental` WRITE;
/*!40000 ALTER TABLE `booksrental` DISABLE KEYS */;
INSERT INTO `booksrental` VALUES (1,1,'d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-07 05:39:02.279000','2025-10-08 05:46:49.855000','2025-10-08 02:40:41.160215','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 02:47:12.099993','d64d97c8-f371-4e2f-8fd2-57f90f4e6946'),(2,6,'d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 00:00:00.000000',NULL,'2025-10-08 18:53:59.817266','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 18:53:59.817414','d64d97c8-f371-4e2f-8fd2-57f90f4e6946'),(3,4,'d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 00:00:00.000000',NULL,'2025-10-08 19:03:56.796335','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 19:03:56.796336','d64d97c8-f371-4e2f-8fd2-57f90f4e6946'),(4,1,'d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 00:00:00.000000',NULL,'2025-10-08 20:07:53.795326','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 20:07:53.795437','d64d97c8-f371-4e2f-8fd2-57f90f4e6946'),(5,7,'d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 00:00:00.000000',NULL,'2025-10-08 20:42:57.304276','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 20:42:57.304374','d64d97c8-f371-4e2f-8fd2-57f90f4e6946'),(6,12,'d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 00:00:00.000000',NULL,'2025-10-08 20:45:39.501774','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-10-08 20:45:39.501774','d64d97c8-f371-4e2f-8fd2-57f90f4e6946'),(7,14,'d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-12-16 00:00:00.000000',NULL,'2025-12-16 13:50:42.781469','d64d97c8-f371-4e2f-8fd2-57f90f4e6946','2025-12-16 13:50:42.781472','d64d97c8-f371-4e2f-8fd2-57f90f4e6946');
/*!40000 ALTER TABLE `booksrental` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genres`
--

DROP TABLE IF EXISTS `genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genres` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Created` datetime(6) NOT NULL,
  `CreatedBy` longtext,
  `LastModified` datetime(6) NOT NULL,
  `LastModifiedBy` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genres`
--

LOCK TABLES `genres` WRITE;
/*!40000 ALTER TABLE `genres` DISABLE KEYS */;
/*!40000 ALTER TABLE `genres` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-12-16 15:29:11
