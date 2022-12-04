-- phpMyAdmin SQL Dump
-- version 4.9.7
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost:3306
-- Üretim Zamanı: 30 Kas 2022, 00:04:56
-- Sunucu sürümü: 8.0.31-cll-lve
-- PHP Sürümü: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `ripeappl_paradoxhr`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `appkeys`
--

CREATE TABLE `appkeys` (
  `id` int NOT NULL,
  `code` varchar(500) NOT NULL,
  `clue` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Tablo döküm verisi `appkeys`
--

INSERT INTO `appkeys` (`id`, `code`, `clue`) VALUES
(1, 'V85LPWZ29U', '29-11-2022 20:24:57'),
(2, 'HQF976VDNJ', '29-11-2022 20:25:02'),
(3, 'QEZ0BL37PU', '29-11-2022 20:46:42'),
(4, 'QXKEPL3YVH', '29-11-2022 20:46:46'),
(5, '9BKZOHQUJY', '29-11-2022 20:46:48'),
(6, 'WDEPZ8LYHB', '29-11-2022 20:46:49');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `id` int NOT NULL,
  `email` varchar(500) NOT NULL,
  `pass` varchar(500) NOT NULL,
  `created_keys` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Tablo döküm verisi `users`
--

INSERT INTO `users` (`id`, `email`, `pass`, `created_keys`) VALUES
(1, 'olgunelmamstf@gmail.com', 'mustafa123', ''),
(2, 'deneme@gmail.com', 'deneme123', 'QEZ0BL37PU,29-11-2022 20:46:42&QXKEPL3YVH,29-11-2022 20:46:46&9BKZOHQUJY,29-11-2022 20:46:48&WDEPZ8LYHB,29-11-2022 20:46:49');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `appkeys`
--
ALTER TABLE `appkeys`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `appkeys`
--
ALTER TABLE `appkeys`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
