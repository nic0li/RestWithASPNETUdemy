CREATE TABLE IF NOT EXISTS `book` (
`id` bigint(20) NOT NULL AUTO_INCREMENT,
`title` longtext,
`author` longtext,
`launch_date` datetime(6) NOT NULL,
`price` decimal(65,2) NOT NULL,
PRIMARY KEY (`id`)
);