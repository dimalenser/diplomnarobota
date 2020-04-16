-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Час створення: Квт 16 2020 р., 14:33
-- Версія сервера: 10.4.11-MariaDB
-- Версія PHP: 7.4.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База даних: `treesbase`
--

-- --------------------------------------------------------

--
-- Структура таблиці `trees`
--

CREATE TABLE `trees` (
  `t_id` int(11) UNSIGNED NOT NULL,
  `t_vik` int(5) NOT NULL,
  `t_stan` int(2) NOT NULL,
  `t_poroda` varchar(11) NOT NULL,
  `t_plodu` varchar(11) NOT NULL,
  `t_ne` varchar(11) NOT NULL,
  `t_info` text NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп даних таблиці `trees`
--

INSERT INTO `trees` (`t_id`, `t_vik`, `t_stan`, `t_poroda`, `t_plodu`, `t_ne`, `t_info`) VALUES
(11, 1985, 5, 'Дуб        ', 'Жолудь   ', '40n25e', ''),
(12, 1975, 4, 'Абрикос  ', 'Абрикос  ', '30n12e', ''),
(13, 1987, 5, 'Береза     ', 'Немає      ', '33n67e', ''),
(14, 1964, 3, 'Вишня     ', 'Вишня     ', '12n34e', ''),
(35, 1953, 2, 'Вишня     ', 'Вишня     ', '78n23e', ''),
(16, 1965, 5, 'Каштан    ', 'Каштан    ', '55n34e', ''),
(17, 1975, 3, 'Клен       ', 'Немає      ', '45n22e', ''),
(18, 2015, 5, 'Слива      ', 'Слива      ', '12n34e', ''),
(19, 2011, 2, 'Сосна      ', 'Немає      ', '45n23e', ''),
(20, 2008, 5, 'Тополя     ', 'Немає      ', '90n12e', ''),
(21, 1944, 5, 'Черешня  ', 'Черешня ', '34n12e', ''),
(33, 1964, 5, 'Черешня  ', 'Черешня ', '33n54e', ''),
(23, 1988, 3, 'Ялинка     ', 'Немає      ', '45n23e', ''),
(25, 1975, 5, 'Слива      ', 'Слива      ', '45n12e', ''),
(26, 2008, 4, 'Яблуня     ', 'Яблука     ', '34n12e', ''),
(27, 1976, 5, 'Клен       ', 'Немає      ', '12n9e', ''),
(28, 2007, 4, 'Ялинка     ', 'Немає      ', '44n23e', ''),
(29, 1980, 5, 'Абрикос  ', 'Абрикос  ', '40n23e', ''),
(30, 1965, 3, 'Дуб        ', 'Немає      ', '23n12e', ''),
(31, 1963, 5, 'Вишня     ', 'Вишня     ', '12n23e', ''),
(32, 1975, 3, 'Береза     ', 'Немає      ', '12n32e', ''),
(34, 1932, 3, 'Абрикос  ', 'Абрикос  ', '50n34e', ''),
(36, 1954, 4, 'Каштан    ', 'Каштан    ', '23n12e', ''),
(37, 1975, 4, 'Дуб        ', 'Немає      ', '23n12e', ''),
(38, 2017, 4, 'Береза     ', 'Немає      ', '40n3e', ''),
(39, 1921, 4, 'Тополя', 'Немає', '123n543e', ''),
(40, 1921, 4, 'Тополя', 'Немає', '123n543e', ''),
(41, 1986, 3, 'Дуб', 'Немає', '432n12e', ''),
(42, 1986, 3, 'Дуб', 'Немає', '432n12e', ''),
(43, 1986, 3, 'Дуб', 'Немає', '432n12e', ''),
(44, 1986, 3, 'Дуб', 'Немає', '432n12e', ''),
(45, 1986, 3, 'Дуб', 'Немає', '432n12e', ''),
(46, 1986, 3, 'Дуб', 'Немає', '432n12e', ''),
(47, 1986, 3, 'Дуб', 'Немає', '432n12e', ''),
(48, 1698, 4, 'Порода', 'Плоди', '12n34e', ''),
(49, 1980, 5, 'Береза', 'Немає', '10т35у', ''),
(50, 1966, 5, 'Дуб', 'Немає', '10н12е', 'Немає');

-- --------------------------------------------------------

--
-- Структура таблиці `users`
--

CREATE TABLE `users` (
  `u_id` int(11) UNSIGNED NOT NULL,
  `u_name` varchar(100) NOT NULL,
  `u_surname` varchar(100) NOT NULL,
  `u_login` varchar(100) NOT NULL,
  `u_password` varchar(32) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп даних таблиці `users`
--

INSERT INTO `users` (`u_id`, `u_name`, `u_surname`, `u_login`, `u_password`) VALUES
(1, 'dimas', 'lenser', 'admin', '123'),
(2, 'Vasul', 'S4erbanyk', 'vasya', '123'),
(3, '????', '????', 'asul', '123'),
(4, 'хтось', 'хтось', 'hros', '1232'),
(5, 'igor', 'lesner', 'lenser2282', '123'),
(6, '123', '123', 'lenser228', '123'),
(7, 'loh', 'loh', 'lenser2281', '123'),
(8, 'вася', 'вася', 'vasik', '123'),
(9, 'Sajmon', 'Nagurski', 'sana', '123'),
(16, 'admin', 'admin', 'admin12', '123'),
(11, 'perto', 'banper', 'petro228', '123'),
(12, 'ads', 'asdas', 'admin1', '123'),
(13, 'jhjjg', 'ml,mm', 'admin9789', ';lklk,.m'),
(14, 'waad', 'essef', 'admin7iuyiuyyu', 'lkjkhkjkjh'),
(15, 'nnbmbn', 'kjhjjkh', 'admin34342', 'jhvjvbmh'),
(17, 'dsaa', 'sdsads', 'dimaslenser', '123');

--
-- Індекси збережених таблиць
--

--
-- Індекси таблиці `trees`
--
ALTER TABLE `trees`
  ADD UNIQUE KEY `id` (`t_id`);

--
-- Індекси таблиці `users`
--
ALTER TABLE `users`
  ADD UNIQUE KEY `id` (`u_id`);

--
-- AUTO_INCREMENT для збережених таблиць
--

--
-- AUTO_INCREMENT для таблиці `trees`
--
ALTER TABLE `trees`
  MODIFY `t_id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT для таблиці `users`
--
ALTER TABLE `users`
  MODIFY `u_id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
