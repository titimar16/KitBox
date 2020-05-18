CREATE DATABASE  IF NOT EXISTS `kitbox` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `kitbox`;
-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: kitbox
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
-- Table structure for table `supplierslistsitems`
--

DROP TABLE IF EXISTS `supplierslistsitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplierslistsitems` (
  `ItemId` int NOT NULL AUTO_INCREMENT,
  `SupplierOrderId` int DEFAULT NULL,
  `Code` varchar(15) DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  PRIMARY KEY (`ItemId`),
  UNIQUE KEY `ItemId_UNIQUE` (`ItemId`),
  KEY `azert_idx` (`SupplierOrderId`),
  CONSTRAINT `azert` FOREIGN KEY (`SupplierOrderId`) REFERENCES `suppliersorders` (`SupplierOrderId`)
) ENGINE=InnoDB AUTO_INCREMENT=316 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplierslistsitems`
--

LOCK TABLES `supplierslistsitems` WRITE;
/*!40000 ALTER TABLE `supplierslistsitems` DISABLE KEYS */;
INSERT INTO `supplierslistsitems` VALUES (1,1,'ANB125BLCUT',32),(3,5,'ANB168BL',1000),(4,6,'CLE47',4),(5,7,'ANB138WH',10),(6,8,'ANB175WHCUT',1000),(7,9,'DOO3242GS',3000),(8,10,'CLE47',8),(9,11,'ANB100BLCUT',1000),(10,11,'ANB100BRCUT',1000),(11,11,'ANB100GLCUT',1000),(12,11,'ANB100WHCUT',1000),(13,11,'ANB108BL',1000),(14,11,'ANB108BR',1000),(15,11,'ANB108GL',1000),(16,11,'ANB108WH',1000),(17,11,'ANB112BL',1000),(18,11,'ANB112BR',1000),(19,11,'ANB112GL',1000),(20,11,'ANB112WH',1000),(21,11,'ANB125BLCUT',1000),(22,11,'ANB125BRCUT',1000),(23,11,'ANB125GLCUT',1000),(24,11,'ANB125WHCUT',1000),(25,11,'ANB138BL',1000),(26,11,'ANB138BR',1000),(27,11,'ANB138GL',1000),(28,11,'ANB138WH',1000),(29,11,'ANB144BL',1000),(30,11,'ANB144BR',1000),(31,11,'ANB144GL',1000),(32,11,'ANB144WH',1000),(33,11,'ANB150BLCUT',1000),(34,11,'ANB150BRCUT',1000),(35,11,'ANB150GLCUT',1000),(36,11,'ANB150WHCUT',1000),(37,11,'ANB168BR',1000),(38,11,'ANB168GL',1000),(39,11,'ANB168WH',1000),(40,11,'ANB175BLCUT',1000),(41,11,'ANB175BRCUT',1000),(42,11,'ANB175GLCUT',1000),(43,11,'ANB180BL',1000),(44,11,'ANB180BR',1000),(45,11,'ANB180GL',1000),(46,11,'ANB180WH',1000),(47,11,'ANB184BL',1000),(48,11,'ANB184BR',1000),(49,11,'ANB184GL',1000),(50,11,'ANB184WH',1000),(51,11,'ANB200BLCUT',1000),(52,11,'ANB200BRCUT',1000),(53,11,'ANB200GLCUT',1000),(54,11,'ANB200WHCUT',1000),(55,11,'ANB216BL',1000),(56,11,'ANB216BR',1000),(57,11,'ANB216GL',1000),(58,11,'ANB216WH',1000),(59,11,'ANB224BL',1000),(60,11,'ANB224BR',1000),(61,11,'ANB224GL',1000),(62,11,'ANB224WH',1000),(63,11,'ANB225BLCUT',1000),(64,11,'ANB225BRCUT',1000),(65,11,'ANB225GLCUT',1000),(66,11,'ANB225WHCUT',1000),(67,11,'ANB230BL',1000),(68,11,'ANB230BR',1000),(69,11,'ANB230GL',1000),(70,11,'ANB230WH',1000),(71,11,'ANB250BLCUT',1000),(72,11,'ANB250BRCUT',1000),(73,11,'ANB250GLCUT',1000),(74,11,'ANB250WHCUT',1000),(75,11,'ANB252BL',1000),(76,11,'ANB252BR',1000),(77,11,'ANB252GL',1000),(78,11,'ANB252WH',1000),(79,11,'ANB275BLCUT',1000),(80,11,'ANB275BRCUT',1000),(81,11,'ANB275GLCUT',1000),(82,11,'ANB275WHCUT',1000),(83,11,'ANB276BL',1000),(84,11,'ANB276BR',1000),(85,11,'ANB276GL',1000),(86,11,'ANB276WH',1000),(87,11,'ANB280BL',1000),(88,11,'ANB280BR',1000),(89,11,'ANB280GL',1000),(90,11,'ANB280WH',1000),(91,11,'ANB300BLCUT',1000),(92,11,'ANB300BRCUT',1000),(93,11,'ANB300GLCUT',1000),(94,11,'ANB300WHCUT',1000),(95,11,'ANB325BLCUT',1000),(96,11,'ANB325BRCUT',1000),(97,11,'ANB325GLCUT',1000),(98,11,'ANB325WHCUT',1000),(99,11,'ANB350BLCUT',1000),(100,11,'ANB350BRCUT',1000),(101,11,'ANB350GLCUT',1000),(102,11,'ANB350WHCUT',1000),(103,11,'ANB36BL',1000),(104,11,'ANB36BR',1000),(105,11,'ANB36GL',1000),(106,11,'ANB36WH',1000),(107,11,'ANB375BLCUT',1000),(108,11,'ANB375BRCUT',1000),(109,11,'ANB375GLCUT',1000),(110,11,'ANB375WHCUT',1000),(111,11,'ANB46BL',1000),(112,11,'ANB46BR',1000),(113,11,'ANB46GL',1000),(114,11,'ANB46WH',1000),(115,11,'ANB50BLCUT',1000),(116,11,'ANB50BRCUT',1000),(117,11,'ANB50GLCUT',1000),(118,11,'ANB50WHCUT',1000),(119,11,'ANB56BL',1000),(120,11,'ANB56BR',1000),(121,11,'ANB56GL',1000),(122,11,'ANB56WH',1000),(123,11,'ANB72BL',1000),(124,11,'ANB72BR',1000),(125,11,'ANB72GL',1000),(126,11,'ANB72WH',1000),(127,11,'ANB75BLCUT',1000),(128,11,'ANB75BRCUT',1000),(129,11,'ANB75GLCUT',1000),(130,11,'ANB75WHCUT',1000),(131,11,'ANB92BL',1000),(132,11,'ANB92BR',1000),(133,11,'ANB92GL',1000),(134,11,'ANB92WH',1000),(135,11,'CBB100',1000),(136,11,'CBB120',1000),(137,11,'CBB32',1000),(138,11,'CBB42',1000),(139,11,'CBB52',1000),(140,11,'CBB62',1000),(141,11,'CBB80',1000),(142,11,'CBF100',1000),(143,11,'CBF120',1000),(144,11,'CBF32',1000),(145,11,'CBF42',1000),(146,11,'CBF52',1000),(147,11,'CBF62',1000),(148,11,'CBF80',1000),(149,11,'CBS32',1000),(150,11,'CBS42',1000),(151,11,'CBS52',1000),(152,11,'CBS62',1000),(153,11,'CLE27',1000),(154,11,'CLE37',1000),(155,11,'CLE47',1000),(156,11,'Cup',1000),(157,11,'DOO3232BR',1000),(158,11,'DOO3232GS',1000),(159,11,'DOO3232WH',1000),(160,11,'DOO3242BR',1000),(161,11,'DOO3242WH',1000),(162,11,'DOO3252BR',1000),(163,11,'DOO3252GS',1000),(164,11,'DOO3252WH',1000),(165,11,'DOO3262BR',1000),(166,11,'DOO3262GS',1000),(167,11,'DOO3262WH',1000),(168,11,'DOO4232BR',1000),(169,11,'DOO4232GS',1000),(170,11,'DOO4232WH',1000),(171,11,'DOO4242BR',1000),(172,11,'DOO4242GS',1000),(173,11,'DOO4242WH',1000),(174,11,'DOO4252BR',1000),(175,11,'DOO4252GS',1000),(176,11,'DOO4252WH',1000),(177,11,'DOO4262BR',1000),(178,11,'DOO4262GS',1000),(179,11,'DOO4262WH',1000),(180,11,'DOO5232BR',1000),(181,11,'DOO5232GS',1000),(182,11,'DOO5232WH',1000),(183,11,'DOO5242BR',1000),(184,11,'DOO5242GS',1000),(185,11,'DOO5242WH',1000),(186,11,'DOO5252BR',1000),(187,11,'DOO5252GS',1000),(188,11,'DOO5252WH',1000),(189,11,'DOO5262BR',1000),(190,11,'DOO5262GS',1000),(191,11,'DOO5262WH',1000),(192,11,'PAB32100BR',1000),(193,11,'PAB32100WH',1000),(194,11,'PAB32120BR',1000),(195,11,'PAB32120WH',1000),(196,11,'PAB3232BR',1000),(197,11,'PAB3232WH',1000),(198,11,'PAB3242BR',1000),(199,11,'PAB3242WH',1000),(200,11,'PAB3252BR',1000),(201,11,'PAB3252WH',1000),(202,11,'PAB3262BR',1000),(203,11,'PAB3262WH',1000),(204,11,'PAB3280BR',1000),(205,11,'PAB3280WH',1000),(206,11,'PAB42100BR',1000),(207,11,'PAB42100WH',1000),(208,11,'PAB42120BR',1000),(209,11,'PAB42120WH',1000),(210,11,'PAB4232BR',1000),(211,11,'PAB4232WH',1000),(212,11,'PAB4242BR',1000),(213,11,'PAB4242WH',1000),(214,11,'PAB4252BR',1000),(215,11,'PAB4252WH',1000),(216,11,'PAB4262BR',1000),(217,11,'PAB4262WH',1000),(218,11,'PAB4280BR',1000),(219,11,'PAB4280WH',1000),(220,11,'PAB52100BR',1000),(221,11,'PAB52100WH',1000),(222,11,'PAB52120BR',1000),(223,11,'PAB52120WH',1000),(224,11,'PAB5232BR',1000),(225,11,'PAB5232WH',1000),(226,11,'PAB5242BR',1000),(227,11,'PAB5242WH',1000),(228,11,'PAB5252BR',1000),(229,11,'PAB5252WH',1000),(230,11,'PAB5262BR',1000),(231,11,'PAB5262WH',1000),(232,11,'PAB5280BR',1000),(233,11,'PAB5280WH',1000),(234,11,'PHL32100BR',1000),(235,11,'PHL32100WH',1000),(236,11,'PHL32120BR',1000),(237,11,'PHL32120WH',1000),(238,11,'PHL3232BR',1000),(239,11,'PHL3232WH',1000),(240,11,'PHL3242BR',1000),(241,11,'PHL3242WH',1000),(242,11,'PHL3252BR',1000),(243,11,'PHL3252WH',1000),(244,11,'PHL3262BR',1000),(245,11,'PHL3262WH',1000),(246,11,'PHL3280BR',1000),(247,11,'PHL3280WH',1000),(248,11,'PHL42100BR',1000),(249,11,'PHL42100WH',1000),(250,11,'PHL42120BR',1000),(251,11,'PHL42120WH',1000),(252,11,'PHL4232BR',1000),(253,11,'PHL4232WH',1000),(254,11,'PHL4242BR',1000),(255,11,'PHL4242WH',1000),(256,11,'PHL4252BR',1000),(257,11,'PHL4252WH',1000),(258,11,'PHL4262BR',1000),(259,11,'PHL4262WH',1000),(260,11,'PHL4280BR',1000),(261,11,'PHL4280WH',1000),(262,11,'PHL52100BR',1000),(263,11,'PHL52100WH',1000),(264,11,'PHL52120BR',1000),(265,11,'PHL52120WH',1000),(266,11,'PHL5232BR',1000),(267,11,'PHL5232WH',1000),(268,11,'PHL5242BR',1000),(269,11,'PHL5242WH',1000),(270,11,'PHL5252BR',1000),(271,11,'PHL5252WH',1000),(272,11,'PHL5262BR',1000),(273,11,'PHL5262WH',1000),(274,11,'PHL5280BR',1000),(275,11,'PHL5280WH',1000),(276,11,'PHL62100BR',1000),(277,11,'PHL62100WH',1000),(278,11,'PHL62120BR',1000),(279,11,'PHL62120WH',1000),(280,11,'PHL6232BR',1000),(281,11,'PHL6232WH',1000),(282,11,'PHL6242BR',1000),(283,11,'PHL6242WH',1000),(284,11,'PHL6252BR',1000),(285,11,'PHL6252WH',1000),(286,11,'PHL6262BR',1000),(287,11,'PHL6262WH',1000),(288,11,'PHL6280BR',1000),(289,11,'PHL6280WH',1000),(290,11,'PLR3232BR',1000),(291,11,'PLR3232WH',1000),(292,11,'PLR3242BR',1000),(293,11,'PLR3242WH',1000),(294,11,'PLR3252BR',1000),(295,11,'PLR3252WH',1000),(296,11,'PLR3262BR',1000),(297,11,'PLR3262WH',1000),(298,11,'PLR4232BR',1000),(299,11,'PLR4232WH',1000),(300,11,'PLR4242BR',1000),(301,11,'PLR4242WH',1000),(302,11,'PLR4252BR',1000),(303,11,'PLR4252WH',1000),(304,11,'PLR4262BR',1000),(305,11,'PLR4262WH',1000),(306,11,'PLR5232BR',1000),(307,11,'PLR5232WH',1000),(308,11,'PLR5242BR',1000),(309,11,'PLR5242WH',1000),(310,11,'PLR5252BR',1000),(311,11,'PLR5252WH',1000),(312,11,'PLR5262BR',1000),(313,11,'PLR5262WH',1000),(314,12,'DOO3252BR',20000),(315,13,'DOO3242WH',2000);
/*!40000 ALTER TABLE `supplierslistsitems` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-18 10:00:47
