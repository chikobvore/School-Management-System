-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 14, 2019 at 04:03 PM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kariangwe_high`
--

-- --------------------------------------------------------

--
-- Table structure for table `allocations`
--

CREATE TABLE `allocations` (
  `Allocation_id` int(11) NOT NULL,
  `Year` varchar(255) DEFAULT NULL,
  `Term` int(11) DEFAULT NULL,
  `Department_id` int(11) DEFAULT NULL,
  `Supervisor` varchar(255) DEFAULT NULL,
  `Amount` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `allocations`
--

INSERT INTO `allocations` (`Allocation_id`, `Year`, `Term`, `Department_id`, `Supervisor`, `Amount`) VALUES
(1, '0000-00-00', 1, 11, 'Japhet Mhandu', 2000);

-- --------------------------------------------------------

--
-- Table structure for table `asserts`
--

CREATE TABLE `asserts` (
  `ReferenceNumber` int(11) NOT NULL,
  `Assert_name` varchar(255) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Purchased_date` varchar(10) DEFAULT NULL,
  `allocation` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `asserts`
--

INSERT INTO `asserts` (`ReferenceNumber`, `Assert_name`, `Quantity`, `Purchased_date`, `allocation`) VALUES
(1, 'chair', 1, '4/11/2019 ', '1 blue');

-- --------------------------------------------------------

--
-- Table structure for table `cooperate_description`
--

CREATE TABLE `cooperate_description` (
  `cooperate_id` int(11) NOT NULL,
  `Representative` int(11) DEFAULT NULL,
  `Name` text NOT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Phone` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Description` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cooperate_description`
--

INSERT INTO `cooperate_description` (`cooperate_id`, `Representative`, `Name`, `Address`, `Phone`, `Email`, `Description`) VALUES
(1, 11, 'Hit', 'ganges road', '04767898', 'hit.ac', 'university');

-- --------------------------------------------------------

--
-- Table structure for table `departments`
--

CREATE TABLE `departments` (
  `Department_id` int(11) NOT NULL,
  `Department_name` varchar(255) DEFAULT NULL,
  `Department_key` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `departments`
--

INSERT INTO `departments` (`Department_id`, `Department_name`, `Department_key`) VALUES
(11, 'Sports', 'Sports 12019');

-- --------------------------------------------------------

--
-- Table structure for table `fees_structure`
--

CREATE TABLE `fees_structure` (
  `fees_id` int(11) NOT NULL,
  `Amount` double DEFAULT NULL,
  `year` char(4) DEFAULT NULL,
  `term` int(11) DEFAULT NULL,
  `lock_key` varchar(8) DEFAULT NULL,
  `status` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fees_structure`
--

INSERT INTO `fees_structure` (`fees_id`, `Amount`, `year`, `term`, `lock_key`, `status`) VALUES
(19, 750, '2019', 1, ' 1 2019', 'current');

-- --------------------------------------------------------

--
-- Table structure for table `fee_heads`
--

CREATE TABLE `fee_heads` (
  `fee_head_id` int(11) NOT NULL,
  `Fee_head` varchar(255) DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `lock_key` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fee_heads`
--

INSERT INTO `fee_heads` (`fee_head_id`, `Fee_head`, `Amount`, `lock_key`) VALUES
(48, 'Levy', 100, ' 1 2019'),
(49, 'Transport', 200, ' 1 2019'),
(50, 'Tuition ', 350, ' 1 2019'),
(51, 'development', 100, ' 1 2019');

-- --------------------------------------------------------

--
-- Table structure for table `payments`
--

CREATE TABLE `payments` (
  `payment_id` int(11) NOT NULL,
  `student_id` varchar(255) DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `purpose` varchar(100) DEFAULT NULL,
  `methods` varchar(100) DEFAULT NULL,
  `Payment_date` text,
  `student_class` varchar(20) NOT NULL,
  `Term` varchar(11) NOT NULL,
  `combination` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `payments`
--

INSERT INTO `payments` (`payment_id`, `student_id`, `Amount`, `purpose`, `methods`, `Payment_date`, `student_class`, `Term`, `combination`) VALUES
(1, '1900B', 245, 'Tuition', 'RTGS', '4/14/2019 12:29:11 PM', 'Blue', '1', '1Blue'),
(11, '1900B', 245, 'Tuition', 'RTGS', '4/5/2019 5:34:43 PM', 'Blue', '1', '1Blue'),
(12, '1903B', 250, 'Tuition', 'RTGS', '4/5/2019 5:42:34 PM', 'Blue', '1', '1Blue'),
(13, '1900B', 25, 'Tuition', 'RTGS', '4/14/2019 12:38:09 PM', 'Blue', '1', '1Blue'),
(14, '1904G', 200, 'Tuition', 'RTGS', '4/14/2019 1:34:00 PM', 'Blue', '1', '1Blue'),
(15, '1904G', 100, 'Tuition', 'RTGS', '4/14/2019 1:35:59 PM', 'Blue', '1', '1Blue');

-- --------------------------------------------------------

--
-- Table structure for table `school_account`
--

CREATE TABLE `school_account` (
  `account_id` int(11) NOT NULL,
  `Total_paid` double DEFAULT NULL,
  `Total_balances` double DEFAULT NULL,
  `Expected_fees` double DEFAULT NULL,
  `Available_amount` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sponsored_funds`
--

CREATE TABLE `sponsored_funds` (
  `items_id` int(11) NOT NULL,
  `sponsor_id` int(11) DEFAULT NULL,
  `type` varchar(50) DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sponsored_funds`
--

INSERT INTO `sponsored_funds` (`items_id`, `sponsor_id`, `type`, `Amount`, `description`) VALUES
(1, 9, 'Money', 0, ''),
(2, 10, 'Money', 100, 'For sports'),
(3, 11, 'Money', 1000, 'development');

-- --------------------------------------------------------

--
-- Table structure for table `sponsored_items`
--

CREATE TABLE `sponsored_items` (
  `items_id` int(11) NOT NULL,
  `sponsor_id` int(11) DEFAULT NULL,
  `type` varchar(50) DEFAULT NULL,
  `item` varchar(255) DEFAULT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sponsored_service`
--

CREATE TABLE `sponsored_service` (
  `items_id` int(11) NOT NULL,
  `sponsor_id` int(11) DEFAULT NULL,
  `type` varchar(50) DEFAULT NULL,
  `service` varchar(255) DEFAULT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sponsor_details`
--

CREATE TABLE `sponsor_details` (
  `sponsor_id` int(11) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Surname` varchar(255) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `type` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sponsor_details`
--

INSERT INTO `sponsor_details` (`sponsor_id`, `Name`, `Surname`, `Email`, `Phone`, `type`) VALUES
(1, 'Nyasha ', 'chikobvore', 'nchikobvor@gmail.com', '0775531297', 'Individual'),
(2, 'Tatenda', 'alice', 'talice@me.com', '0771366375', 'Individual'),
(3, 'Tatenda', 'alice', 'talice@me.com', '0771366375', 'Individual'),
(4, 'Munashe', 'k', 'mk@me.com', '0771366375', 'Individual'),
(5, 'panashe', 'k', 'pk@me.com', '0771366375', 'Individual'),
(6, 'alfred', 'murombedsa', 'am@me.kom', '099999', 'Individual'),
(7, 'kudsai ', 'takunda', 'tk@gmail.com', '0776545678', 'Individual'),
(8, 'solo', 'kiwa', 'sk@me.kom', '0978', 'Individual'),
(9, 'john', 'doe', 'johndoe@me.kom', '0771234567', 'Individual'),
(10, 'musoro', 'wegomo', 'mw@me.kom', '0775531297', 'Individual'),
(11, 'Nyasha', 'chikobvore', 'nchikobvor@gmail.com', '0718831297', 'co-operate');

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

CREATE TABLE `staff` (
  `teacher_id` int(11) NOT NULL,
  `Name` varchar(30) DEFAULT NULL,
  `Surname` varchar(40) DEFAULT NULL,
  `ec_number` varchar(12) NOT NULL,
  `National_id` varchar(34) NOT NULL,
  `Gender` varchar(6) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Role` varchar(30) DEFAULT NULL,
  `Qualifications` text,
  `Password` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`teacher_id`, `Name`, `Surname`, `ec_number`, `National_id`, `Gender`, `Email`, `Phone`, `Role`, `Qualifications`, `Password`) VALUES
(1, 'Nhlanhla', 'Ngwenya', '1234', '123456789', 'Male', 'nngwenya@gmail.com', '0775531297', 'Headmaster', 'Masters in Education', 'headmaster'),
(14, 'Bonface', 'chirangwe', '01234', '12-23456-l09', 'Female', 'bchirangwe@gmail.com', '0775531297', 'Bursar', 'Diploma in accounting', '1'),
(15, 'Japhet', 'Mhandu', '0101', '12-98765l-09', 'Male', 'jm@me.com', '07890235', 'Teacher', 'Teaching degree', NULL),
(16, 'The', 'Deputy', '1111', '123456789', 'Male', 'td@kariangwe', '08778', 'Deputy', 'matsers', '1'),
(17, 'The', 'clrk', '12345', '1234567', 'Male', 'tk@tk', '0899999', 'clerk', 'rfrf', '1');

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `student_id` char(10) NOT NULL,
  `Name` varchar(30) DEFAULT NULL,
  `Surname` varchar(40) DEFAULT NULL,
  `Date_of_Birth` varchar(20) DEFAULT NULL,
  `Gender` varchar(6) DEFAULT NULL,
  `Address` text,
  `form` int(11) DEFAULT NULL,
  `student_class` varchar(20) DEFAULT NULL,
  `sponsor` varchar(40) DEFAULT NULL,
  `SponsorName` varchar(50) NOT NULL,
  `Sponsorcontact` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`student_id`, `Name`, `Surname`, `Date_of_Birth`, `Gender`, `Address`, `form`, `student_class`, `sponsor`, `SponsorName`, `Sponsorcontact`) VALUES
('1900B', 'alfred', 'marombedsa', '15/15/94', 'Male', 'h6', 4, 'GREEN', 'Donors', 'Nyaradso', '0982'),
('1901B', 'alfred', 'marombedsa', '15/15/94', 'Male', '', 3, 'BLUE', 'Parent', '', ''),
('1902B', 'tinashe', 'imbwaa', '10/03/2010', 'Male', '', 5, 'BLUE', 'Parent', '', ''),
('1903B', 'nyasha', 'chikobvore', '02/02/98', 'Male', '', 1, 'BLUE', 'Parent', '', ''),
('1904G', 'Musoro', 'wegomo', '02/02/11', 'Female', 'H5 Belvedere', 2, 'GREEN', 'Donors', 'Tatenda ', 'Mudiwa'),
('1905G', 'Nyasha', 'chetse', '02/02/01', 'Female', 'HARARE', 3, 'GREEN', 'Parent', 'Alpha', 'omega');

-- --------------------------------------------------------

--
-- Table structure for table `student_portal`
--

CREATE TABLE `student_portal` (
  `portal_id` int(11) NOT NULL,
  `student_id` varchar(10) DEFAULT NULL,
  `Paid_amount` double DEFAULT NULL,
  `Balance` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `student_portal`
--

INSERT INTO `student_portal` (`portal_id`, `student_id`, `Paid_amount`, `Balance`) VALUES
(1, '1900B', 515, -15),
(2, '1904G', 300, 200);

-- --------------------------------------------------------

--
-- Table structure for table `withdraws`
--

CREATE TABLE `withdraws` (
  `transaction_id` int(11) NOT NULL,
  `Transaction_date` varchar(255) DEFAULT NULL,
  `Department_id` int(11) DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `Purpose` varchar(255) DEFAULT NULL,
  `Mathod` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `withdraws`
--

INSERT INTO `withdraws` (`transaction_id`, `Transaction_date`, `Department_id`, `Amount`, `Purpose`, `Mathod`) VALUES
(1, '4/1/2019 8:20:01 PM', 11, 100, 'food', 'RTGS'),
(2, '4/2/2019 4:31:26 PM', 11, 200, 'food', 'RTGS');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `allocations`
--
ALTER TABLE `allocations`
  ADD PRIMARY KEY (`Allocation_id`),
  ADD KEY `Department_id` (`Department_id`);

--
-- Indexes for table `cooperate_description`
--
ALTER TABLE `cooperate_description`
  ADD PRIMARY KEY (`cooperate_id`),
  ADD KEY `Respresentative` (`Representative`);

--
-- Indexes for table `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`Department_id`),
  ADD UNIQUE KEY `Department_key` (`Department_key`);

--
-- Indexes for table `fees_structure`
--
ALTER TABLE `fees_structure`
  ADD PRIMARY KEY (`fees_id`),
  ADD UNIQUE KEY `lock_key` (`lock_key`);

--
-- Indexes for table `fee_heads`
--
ALTER TABLE `fee_heads`
  ADD PRIMARY KEY (`fee_head_id`);

--
-- Indexes for table `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`payment_id`),
  ADD KEY `student_id` (`student_id`);

--
-- Indexes for table `school_account`
--
ALTER TABLE `school_account`
  ADD PRIMARY KEY (`account_id`);

--
-- Indexes for table `sponsored_funds`
--
ALTER TABLE `sponsored_funds`
  ADD PRIMARY KEY (`items_id`),
  ADD KEY `sponsor_id` (`sponsor_id`);

--
-- Indexes for table `sponsored_items`
--
ALTER TABLE `sponsored_items`
  ADD PRIMARY KEY (`items_id`),
  ADD KEY `sponsor_id` (`sponsor_id`);

--
-- Indexes for table `sponsored_service`
--
ALTER TABLE `sponsored_service`
  ADD PRIMARY KEY (`items_id`),
  ADD KEY `sponsor_id` (`sponsor_id`);

--
-- Indexes for table `sponsor_details`
--
ALTER TABLE `sponsor_details`
  ADD PRIMARY KEY (`sponsor_id`);

--
-- Indexes for table `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`teacher_id`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`student_id`);

--
-- Indexes for table `student_portal`
--
ALTER TABLE `student_portal`
  ADD PRIMARY KEY (`portal_id`),
  ADD UNIQUE KEY `student_id` (`student_id`);

--
-- Indexes for table `withdraws`
--
ALTER TABLE `withdraws`
  ADD PRIMARY KEY (`transaction_id`),
  ADD KEY `Department_id` (`Department_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `allocations`
--
ALTER TABLE `allocations`
  MODIFY `Allocation_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `cooperate_description`
--
ALTER TABLE `cooperate_description`
  MODIFY `cooperate_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `departments`
--
ALTER TABLE `departments`
  MODIFY `Department_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `fees_structure`
--
ALTER TABLE `fees_structure`
  MODIFY `fees_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `fee_heads`
--
ALTER TABLE `fee_heads`
  MODIFY `fee_head_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT for table `payments`
--
ALTER TABLE `payments`
  MODIFY `payment_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `student_portal`
--
ALTER TABLE `student_portal`
  MODIFY `portal_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `student_portal`
--
ALTER TABLE `student_portal`
  ADD CONSTRAINT `student_portal_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
