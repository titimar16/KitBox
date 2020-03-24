CREATE DATABASE  IF NOT EXISTS `kitbox` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `kitbox`;
-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: kitbox
-- ------------------------------------------------------
-- Server version	8.0.19

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
-- Table structure for table `crossbars`
--

DROP TABLE IF EXISTS `crossbars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `crossbars` (
  `CrossbarId` int NOT NULL AUTO_INCREMENT,
  `BoxeId` int DEFAULT NULL,
  `Code` text,
  `Position` text,
  PRIMARY KEY (`CrossbarId`),
  KEY `it_idx` (`BoxeId`),
  CONSTRAINT `it` FOREIGN KEY (`BoxeId`) REFERENCES `boxes` (`BoxeId`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crossbars`
--

LOCK TABLES `crossbars` WRITE;
/*!40000 ALTER TABLE `crossbars` DISABLE KEYS */;
INSERT INTO `crossbars` VALUES (1,1,'TRF100','HF'),(2,1,'TRF100','LF'),(3,1,'TRG52','HL'),(4,1,'TRG52','HR'),(5,1,'TRG52','LL'),(6,1,'TRG52','LR'),(7,1,'TRR100','HB'),(8,1,'TRR100','LB'),(9,2,'TRF100','HF'),(10,2,'TRF100','LF'),(11,2,'TRG52','HL'),(12,2,'TRG52','HR'),(13,2,'TRG52','LL'),(14,2,'TRG52','LR'),(15,2,'TRR100','HB'),(16,2,'TRR100','LB');
/*!40000 ALTER TABLE `crossbars` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-24 12:30:03
