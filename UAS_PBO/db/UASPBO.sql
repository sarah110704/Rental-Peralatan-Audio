-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.30 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for soundeasebandung
CREATE DATABASE IF NOT EXISTS `soundeasebandung` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `soundeasebandung`;

-- Dumping structure for table soundeasebandung.equipment
CREATE TABLE IF NOT EXISTS `equipment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `category` varchar(50) NOT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `rental_price` decimal(10,2) NOT NULL,
  `stock` int NOT NULL,
  `description` text,
  `image_path` varchar(255) NOT NULL,
  `status` enum('Tersedia','Tidak Tersedia','Perawatan') NOT NULL DEFAULT 'Tersedia',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table soundeasebandung.equipment: ~3 rows (approximately)
INSERT INTO `equipment` (`id`, `name`, `category`, `brand`, `rental_price`, `stock`, `description`, `image_path`, `status`) VALUES
	(1, 'Yamaha DXR12', 'Speaker', 'Yamaha', 250000.00, 5, 'Speaker aktif 12 inch dengan output 1100W.', 'images/yamaha_dxr12.jpg', 'Tersedia'),
	(2, 'Shure SM58', 'Microphone', 'Shure', 50000.00, 10, 'Microphone dinamis untuk vokal.', 'images/shure_sm58.jpg', 'Tersedia'),
	(5, 'Shure SM57', 'Microphone', 'Yamaha', 255.00, 10, 'Mantap', 'images/sm57', 'Tersedia');

-- Dumping structure for table soundeasebandung.users
CREATE TABLE IF NOT EXISTS `users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `PhoneNumber` varchar(20) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `Gender` enum('Pria','Wanita') NOT NULL,
  `Address` varchar(255) NOT NULL,
  `Role` enum('Admin','Customer') NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Username` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table soundeasebandung.users: ~4 rows (approximately)
INSERT INTO `users` (`Id`, `FirstName`, `LastName`, `PhoneNumber`, `Username`, `PasswordHash`, `Gender`, `Address`, `Role`) VALUES
	(2, 'customer', 'octa', '08821234567', 'octaT', '2efb1047074f7a387fa60c82d2b05bc742cfaf8163ccbb2012cb61108f87fa4f', 'Pria', 'Customer', 'Customer'),
	(3, 'Octa', 'Toriq', '092831923', 'Astheria', 'b041c0aeb35bb0fa4aa668ca5a920b590196fdaf9a00eb852c9b7f4d123cc6d6', 'Pria', 'Cempaka Raharja', 'Customer'),
	(4, 'customer', 'customer', '08821234567', 'customer', 'e6f59d120b99238e3a81b7322136ac9be6f9e27c764f8daca738f68c16a62202', 'Pria', 'jl.audio', 'Customer'),
	(5, 'asdwasdw', 'asdwasd', '0882002252833', 'Astheria_', '2efb1047074f7a387fa60c82d2b05bc742cfaf8163ccbb2012cb61108f87fa4f', 'Pria', 'Customer', 'Customer');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
