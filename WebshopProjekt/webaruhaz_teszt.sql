-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Ápr 21. 06:17
-- Kiszolgáló verziója: 10.4.22-MariaDB
-- PHP verzió: 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `webaruhaz_teszt`
--
CREATE DATABASE IF NOT EXISTS `webaruhaz_teszt` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `webaruhaz_teszt`;
-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `Felhasznalonev` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `Jelszo` varchar(255) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `admin`
--

INSERT INTO `admin` (`id`, `Felhasznalonev`, `Jelszo`) VALUES
(1, 'Erika', '$2a$11$2HDzxPRBamgZIit3oamm/uWn3uqHib4YykkasB33jAKb51wbresKK'),
(2, 'Noemi', '$2a$11$22t00hVQYMQ62pxrCjTNge7GVkGqk6cQoHADoldh4SibCDgSy5ltq');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rendeles`
--

CREATE TABLE `rendeles` (
  `Rendeles_id` int(11) NOT NULL,
  `Vasarlo_id` int(11) DEFAULT NULL,
  `Rendeles_datuma` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `rendeles`
--

INSERT INTO `rendeles` (`Rendeles_id`, `Vasarlo_id`, `Rendeles_datuma`) VALUES
(1, 1, '2022-02-20'),
(2, NULL, NULL),
(3, 1, '2022-03-01'),
(4, 7, '2022-04-15'),
(5, 7, '2022-04-15'),
(6, 7, '2022-04-15'),
(7, 10, '2022-04-15'),
(8, 10, '2022-04-15'),
(9, 10, '2022-04-15'),
(10, 5, '2022-04-15'),
(11, 5, '2022-04-15'),
(12, 1, '2022-04-15'),
(13, 1, '2022-04-15'),
(14, 1, '2022-04-15'),
(15, 1, '2022-04-15'),
(16, 1, '2022-04-15'),
(17, 1, '2022-04-15'),
(18, 10, '2022-04-15'),
(19, 10, '2022-04-15'),
(20, 3, '2022-04-15'),
(21, 3, '2022-04-15'),
(22, 3, '2022-04-15'),
(23, 8, '2022-04-15'),
(24, 8, '2022-04-15');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rendelesi_tetelek`
--

CREATE TABLE `rendelesi_tetelek` (
  `Rendelesi_tetelek_id` int(11) NOT NULL,
  `Rendeles_id` int(11) DEFAULT NULL,
  `Cikkszam` int(10) NOT NULL,
  `Mennyiseg` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `rendelesi_tetelek`
--

INSERT INTO `rendelesi_tetelek` (`Rendelesi_tetelek_id`, `Rendeles_id`, `Cikkszam`, `Mennyiseg`) VALUES
(1, 1, 21033, 5),
(2, 2, 25661, 4),
(3, 3, 26970, 7),
(4, 8, 15955, 87),
(5, 17, 15955, 8),
(6, 18, 15955, 5),
(7, 21, 15955, 9),
(8, 22, 15955, 9),
(9, 23, 25478, 2),
(10, 24, 25478, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termek`
--

CREATE TABLE `termek` (
  `Cikkszam` int(10) NOT NULL,
  `Cikknev` varchar(50) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Gyarto` varchar(50) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `KeszletDB` int(11) DEFAULT NULL,
  `Beszerzesi_ar` int(11) DEFAULT NULL,
  `Eladasi_ar` int(11) DEFAULT NULL,
  `Kiszereles` varchar(15) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Beszerzes_datuma` date DEFAULT NULL,
  `Foto` varchar(255) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Akcios_e` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `termek`
--

INSERT INTO `termek` (`Cikkszam`, `Cikknev`, `Gyarto`, `KeszletDB`, `Beszerzesi_ar`, `Eladasi_ar`, `Kiszereles`, `Beszerzes_datuma`, `Foto`, `Akcios_e`) VALUES
(2467, 'Podravka vegeta 1kg', 'Podravka', 15, 1200, 1372, '1 kg', '2021-10-25', NULL, 0),
(4197, 'Gyermelyi eperlevél 8 tojásos 250g', 'Gyermelyi', 45, 350, 400, '250 g', '2021-10-28', NULL, 0),
(4908, 'Cba finomliszt 1kg', 'Cba', 78, 100, 114, '1 kg', '2021-11-07', NULL, 0),
(5583, 'Knorr leveskocka 80g', 'Knorr', 22, 370, 423, '80 g', '2021-11-16', NULL, 0),
(8287, 'Gluténmentes tészta kagyló 500g', 'Virgin', 25, 480, 549, '500 g', '2021-10-25', NULL, 0),
(8289, 'Gluténmentes tészta kiskocka 500g', 'Virgin', 17, 480, 549, '500 g', '2021-10-28', NULL, 0),
(10643, 'Knorr fűszervarázs fasírt 40g', 'Knorr', 16, 125, 143, '40 g', '2021-10-29', NULL, 0),
(10644, 'Knorr fűszervarázs sertéssült 30g', 'Knorr', 31, 110, 126, '30 g', '2021-11-15', NULL, 0),
(11702, 'Újházi csigatészta 8 tojásos 200g', 'Újházi', 36, 300, 343, '200 g', '2021-11-18', NULL, 0),
(12571, 'Szatmári finomliszt 1kg', 'Szatmári', 52, 120, 137, '1 kg', '2021-10-27', NULL, 1),
(14909, 'Vitamill finomliszt 1kg', 'Vitamill', 58, 240, 274, '1 kg', '2021-11-04', NULL, 0),
(14910, 'Vitamill grahamliszt 1kg', 'Vitamill', 41, 240, 274, '1 kg', '2021-11-09', NULL, 0),
(15955, 'Biopont rizsliszt 500g', 'Biopont', 18, 240, 274, '500 g', '2021-11-05', NULL, 0),
(16649, 'Lisztkeverék teljes kiörlésű 5kg', 'Dia-wellness', 4, 2500, 2858, '5 kg', '2021-11-09', NULL, 0),
(16657, 'Lisztkeverék sötét magvas 2kg', 'Dia-wellness', 9, 2000, 2286, '2 kg', '2021-11-05', NULL, 0),
(16659, 'Lisztkeverék rozsos 5kg', 'Dia-wellness', 7, 2500, 2858, '5 kg', '2021-11-02', NULL, 0),
(21033, 'Farmer tej 1,5% 1l ', 'Farmer', 25, 98, 112, '1 l', '2021-11-09', NULL, 0),
(22619, 'Lucullus gastro feketebors őrölt 250g', 'Lucullus', 6, 90, 103, '250 g', '2021-10-30', NULL, 0),
(25314, 'Izsáki Durum Szarvacska 500g', NULL, 38, NULL, NULL, NULL, '2021-10-31', NULL, NULL),
(25467, 'Eszterházi Szelet 250g', 'Márta Dániel ev', 40, 150, 210, '250 g', '2021-10-25', NULL, 0),
(25478, 'Meggyes Kocka 250g', 'Márta Dániel ev', 20, 150, 210, '250 g', '2021-10-28', NULL, 0),
(25488, 'Sajtos Masni Sós Teasütemény', 'Benei', 15, 900, 1257, '5 kg', '2021-10-29', NULL, 0),
(25661, 'Cba Camembert Natúr 90g', 'Cba', 16, 104, 119, '90 g', '2021-11-05', NULL, 0),
(26057, 'Maggi Tyúkhúsleveskocka zöldséges 66g', 'Maggi', 91, 380, 434, '66 g', '2021-11-04', NULL, 0),
(26970, 'Cba Friss Tej 2,8% 1l', 'Cba', 32, 89, 102, '1 l', '2021-11-02', NULL, 0),
(27371, 'Tolle Tejföl 20 % 325g', 'Tolle', 56, 156, 178, '325 g', '2021-10-30', NULL, 1),
(35366, 'Vegeta gulyásleves és pörköltkocka 60g ', 'Vegeta', 14, 350, 400, '60 g', '2021-11-10', NULL, 0),
(40522, 'Zott natúr joghurt 1kg', 'Zott', 8, 200, 229, '1 kg', '2021-10-31', NULL, 0),
(41621, 'Gyermelyi durum fogósliszt 1 kg', 'Gyermelyi', 25, 800, 914, '1 kg', '2021-11-07', NULL, 0),
(52882, 'Alföldi tej 2,8% 0,5l', 'Alföldi', 18, 102, 117, '0,5 l', '2021-11-04', NULL, 0),
(53624, 'Falujava trappista 700g', 'Falujava', 54, 639, 730, '700 g', '2021-11-10', NULL, 0),
(53853, 'Nádudvari kefír 375g', 'Nádudvari', 1, 120, 137, '375 g', '2021-11-07', NULL, 0),
(53953, 'Tihany camembert 120g', 'Tihany', 22, 136, 155, '120 g', '2021-11-16', NULL, 0),
(54089, 'MIZO BOCI joghurtital 250ml', 'Mizo', 98, 112, 128, '250 ml', '2021-10-25', NULL, 0),
(54226, 'Tihany Füstölt Mozzarella 200g', 'Tihany', 27, 250, 286, '200 g', '2021-10-28', NULL, 0),
(54689, 'Narancsos szelet 250g', 'Márta Dániel ev', 5, 150, 210, '250 g', '2021-11-15', NULL, 1),
(54714, 'Sós rúd', 'Benei', 20, 900, 1257, '5 kg', '2021-11-18', NULL, 0),
(54730, 'Sós kalács 1kg', 'Ceres', 7, 550, 780, '1 kg', '2021-10-27', NULL, 0),
(54753, 'Fánk eper ízű bevonattal 56 g', 'Hana Ice Team', 10, 39, 45, '56 g', '2021-11-04', NULL, 0),
(54764, 'Tejes Kifli', 'Fornetti', 12, 20, 23, '45 g', '2021-11-09', NULL, 0),
(54775, 'Sajtkrémes rúd 100g', 'Fornetti', 2, 80, 91, '100 g', '2021-11-05', NULL, 0),
(54777, 'Virslis rúd 100g', 'Fornetti', 4, 80, 91, '100 g', '2021-11-15', NULL, 0),
(54972, 'Fehér kenyér (szeletelt) 1kg ', 'Ceres', 17, 200, 229, '1 kg', '2021-11-18', NULL, 1),
(54975, 'Burgonyás kenyér(szeletelt) 750g', 'Ceres', 11, 250, 286, '750 g', '2021-10-27', NULL, 0),
(54982, 'Tönköly kenyér (szeletelt) 500g', 'Ceres', 4, 250, 286, '500 g', '2021-11-04', NULL, 0),
(55898, 'Barna kenyér 1kg', 'Ceres', 10, 200, 229, '1 kg', '2021-11-09', NULL, 0),
(60131, 'Csokoládé torta 20 szeletes', 'Márta Dániel ev', 3, 3000, 4191, '20 szelet', '2021-11-05', NULL, 0),
(61281, 'Jogobella joghurtital 1l', 'Jogobella', 78, 104, 119, '1 l', '2021-10-29', NULL, 0),
(61925, 'Família Csigatészta 8 tojásos 200g', 'Família', 22, 300, 343, '200 g', '2021-11-16', NULL, 0),
(62471, 'Kakaós kalács 500g', 'Ceres', 4, 350, 600, '500 g', '2021-11-09', NULL, 0),
(62897, 'Gluténmentes betűtészta 200g', 'Virgin', 25, 300, 343, '200 g', '2021-10-25', NULL, 0),
(63119, 'Mizo kefír 330g', 'Mizo', 10, 110, 126, '330 g', '2021-11-15', NULL, 0),
(63469, 'Mizo tejföl 12% 150g', 'Mizo', 25, 57, 65, '150 g', '2021-11-18', NULL, 0),
(63676, 'Magyar kefír 375g', 'Magyar', 78, 99, 113, '375 g', '2021-10-27', NULL, 0),
(64861, 'Italiana Durum Fodros Nagykocka 500g', 'Italiana', 17, 400, 457, '500 g', '2021-10-28', NULL, 0),
(65367, 'Magyar joghurt barack 150g', 'Magyar', 88, 56, 64, '150 g', '2021-11-04', NULL, 0),
(65497, 'Famíliatészta Durum Orsó 400g', 'Família', 16, 380, 434, '400 g', '2021-10-29', NULL, 1),
(66735, 'Fonott kalács 1kg', 'Ceres', 7, 500, 750, '1 kg', '2021-11-05', NULL, 0),
(66755, 'Riska joghurt eper 140g', 'Riska', 6, 56, 64, '140 g', '2021-11-09', NULL, 1),
(67270, 'Talléros füstölt sajt 1kg', 'Talléros', 30, 858, 981, '1 kg', '2021-11-05', NULL, 0),
(67271, 'Hajdúsági trappista 300g', 'Hajdúsági', 12, 304, 347, '300 g', '2021-11-09', NULL, 0),
(67408, 'Sajtos-Bacononos Csavart 70g', 'Benei', 11, 900, 1257, '70 g', '2021-11-02', NULL, 0),
(68074, 'Mesés natúr joghurt 150g', 'Mesés', 19, 142, 162, '150 g', '2021-11-05', NULL, 0),
(69392, 'Hajdú sajt füstölt 350g', 'Hajdúsági', 5, 342, 391, '350 g', '2021-11-02', NULL, 0),
(70560, 'Dobos torta 18 szeletes', 'Márta Dániel ev', 1, 2500, 3493, '18 szelet', '2021-10-30', NULL, 0),
(70808, 'Epertöltelékes csokis fánk 73 g', 'Hana Ice Team', 2, 39, 45, '73 g', '2021-10-31', NULL, 0),
(70824, 'Kakaós Csiga 90g', 'Fornetti', 8, 90, 103, '90 g', '2021-11-04', NULL, 0),
(70836, 'Málnalekváros fánk 75 g', 'Hana Ice Team', 2, 39, 45, '75 g', '2021-11-10', NULL, 1),
(71547, 'Zott meggyes joghurt 500g', 'Zott', 62, 60, 69, '500 g ', '2021-10-30', NULL, 0),
(72888, 'Foszlós kalács 500g', 'Ceres', 20, 350, 600, '500 g', '2021-11-07', NULL, 0),
(72956, 'Hajdú Camembert fadobozos 250g', 'Hajdúsági', 45, 192, 219, '250 g', '2021-10-31', NULL, 0),
(74120, 'Mascarpone torta 24 szeletes', 'Márta Dániel ev', 1, 3500, 4890, '24 szelet', '2021-11-16', NULL, 0),
(74553, 'Jogobella epres ivójoghurt 300g', 'Jogobella', 49, 133, 152, '300 g', '2021-11-04', NULL, 0),
(76653, 'Zott natúr joghurt 125g', 'Zott', 55, 106, 121, '125 g', '2021-11-10', NULL, 0),
(82082, 'Nádudvari tejföl 12% 700g', 'Nádudvari', 9, 322, 368, '700 g', '2021-11-07', NULL, 0),
(82845, 'Lacikonyha erőleveskocka 60g', 'Lacikonyha', 31, 350, 400, '60 g', '2021-11-15', NULL, 0),
(88326, 'Ammerland trappista 500g', 'Ammerland', 13, 603, 689, '500 g ', '2021-11-16', NULL, 0),
(92492, 'Gyermelyi pizzaliszt 1kg', 'Gyermelyi', 36, 250, 286, '1 kg', '2021-11-18', NULL, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vasarlo`
--

CREATE TABLE `vasarlo` (
  `Vasarlo_id` int(11) NOT NULL,
  `Vezeteknev` varchar(50) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Keresztnev` varchar(50) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Email` varchar(50) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Telefonszam` varchar(20) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Felhasznalonev` varchar(50) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Jelszo` varchar(50) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Varos` varchar(50) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Cim` varchar(50) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Iranyitoszam` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `vasarlo`
--

INSERT INTO `vasarlo` (`Vasarlo_id`, `Vezeteknev`, `Keresztnev`, `Email`, `Telefonszam`, `Felhasznalonev`, `Jelszo`, `Varos`, `Cim`, `Iranyitoszam`) VALUES
(1, 'Nagy', 'Áron', 'nagyaron@gmail.com', '+701234567', 'Nagya', 'nagya', 'Szeged', 'Kis u 34', 6723),
(2, 'Kis', 'Ágnes', 'kisagnes@gmail.com', '+707654321', 'Kisa', 'kisa', 'Szeged', 'Ipoly sor 100', 6724),
(3, 'Czékus', 'Katalin', 'czekuskati@gmail.com', '+301234567', 'Czekk', 'czekk', 'Zsombó', 'Kert u 55', 6764),
(4, 'Tóth', 'Csaba', 'tothcsaba@gmail.com', '+307654321', 'Tothcs', 'tothcs', 'Zsombó', 'Posta u 78', 6764),
(5, 'Hajas', 'Valéria', 'hajasvali@gmail.com', '+201234567', 'Hajasv', 'hajasv', 'Szatymaz', 'Rózsa u 99', 6763),
(6, 'Farkas', 'László', 'farkaslaci@gmail.com', '+207654321', 'Farkasl', 'farkasl', 'Szatymaz', 'Kossuth u 52', 6763),
(7, 'Gera', 'Edina', 'geraedina@gmail.com', '+707777555', 'Gerae', 'gerae', 'Sándorfalva', 'Rigó u 8', 6762),
(8, 'Fekete', 'Ágnes', 'feketeagnes@gmail.com', '+705557777', 'Feketea', 'feketea', 'Sándorfalva', 'Citera u 7', 6762),
(9, 'Ördögh', 'Antal', 'ordoghantal@gmail.com', '+305556666', 'Ordogha', 'ordogha', 'Szeged', 'Gáz u 12', 6723),
(10, 'Szabó', 'Péter', 'szabopeter@gmail.com', '+205557777', 'Szabop', 'szabop', 'Szeged', 'Fácán u 6', 6724);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `rendeles`
--
ALTER TABLE `rendeles`
  ADD PRIMARY KEY (`Rendeles_id`),
  ADD KEY `Vasarlo_id` (`Vasarlo_id`);

--
-- A tábla indexei `rendelesi_tetelek`
--
ALTER TABLE `rendelesi_tetelek`
  ADD PRIMARY KEY (`Rendelesi_tetelek_id`),
  ADD KEY `Rendeles_id` (`Rendeles_id`),
  ADD KEY `Cikkszam` (`Cikkszam`);

--
-- A tábla indexei `termek`
--
ALTER TABLE `termek`
  ADD PRIMARY KEY (`Cikkszam`);

--
-- A tábla indexei `vasarlo`
--
ALTER TABLE `vasarlo`
  ADD PRIMARY KEY (`Vasarlo_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `rendeles`
--
ALTER TABLE `rendeles`
  MODIFY `Rendeles_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT a táblához `rendelesi_tetelek`
--
ALTER TABLE `rendelesi_tetelek`
  MODIFY `Rendelesi_tetelek_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `rendeles`
--
ALTER TABLE `rendeles`
  ADD CONSTRAINT `rendeles_ibfk_1` FOREIGN KEY (`Vasarlo_id`) REFERENCES `vasarlo` (`Vasarlo_id`);

--
-- Megkötések a táblához `rendelesi_tetelek`
--
ALTER TABLE `rendelesi_tetelek`
  ADD CONSTRAINT `rendelesi_tetelek_ibfk_1` FOREIGN KEY (`Rendeles_id`) REFERENCES `rendeles` (`Rendeles_id`),
  ADD CONSTRAINT `rendelesi_tetelek_ibfk_2` FOREIGN KEY (`Cikkszam`) REFERENCES `termek` (`Cikkszam`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
