-- MySQL Script generated by MySQL Workbench
-- Thu Aug 31 21:01:43 2017
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
SHOW WARNINGS;
-- -----------------------------------------------------
-- Schema UniProtKB
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `UniProtKB` ;

-- -----------------------------------------------------
-- Schema UniProtKB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `UniProtKB` DEFAULT CHARACTER SET utf8 ;
SHOW WARNINGS;
USE `UniProtKB` ;

-- -----------------------------------------------------
-- Table `UniProtKB`.`id_mappings`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `UniProtKB`.`id_mappings` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `UniProtKB`.`id_mappings` (
  `UniProtKB_AC` INT(11) NOT NULL,
  `UniProtKB_ID` VARCHAR(45) NULL DEFAULT NULL,
  `GeneID_EntrezGene` VARCHAR(45) NULL DEFAULT NULL,
  `RefSeq` VARCHAR(45) NULL DEFAULT NULL,
  `GI` VARCHAR(45) NULL DEFAULT NULL,
  `pdb` VARCHAR(45) NULL DEFAULT NULL,
  `go` VARCHAR(45) NULL DEFAULT NULL,
  `UniRef100` VARCHAR(45) NULL DEFAULT NULL,
  `UniRef90` VARCHAR(45) NULL DEFAULT NULL,
  `UniRef50` VARCHAR(45) NULL DEFAULT NULL,
  `UniParc` VARCHAR(45) NULL DEFAULT NULL,
  `pir` VARCHAR(45) NULL DEFAULT NULL,
  `NCBI_Taxon` VARCHAR(45) NULL DEFAULT NULL,
  `MIM` VARCHAR(45) NULL DEFAULT NULL,
  `UniGene` VARCHAR(45) NULL DEFAULT NULL,
  `PubMed` VARCHAR(45) NULL DEFAULT NULL,
  `EMBL` VARCHAR(45) NULL DEFAULT NULL,
  `EMBL_CDS` VARCHAR(45) NULL DEFAULT NULL,
  `Ensembl` VARCHAR(45) NULL DEFAULT NULL,
  `Ensembl_TRS` VARCHAR(45) NULL DEFAULT NULL,
  `Ensembl_PRO` VARCHAR(45) NULL DEFAULT NULL,
  `Additional_PubMed` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`UniProtKB_AC`),
  UNIQUE INDEX `UniProtKB_AC_UNIQUE` (`UniProtKB_AC` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `UniProtKB`.`organism_code`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `UniProtKB`.`organism_code` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `UniProtKB`.`organism_code` (
  `uid` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `organism_name` VARCHAR(100) NOT NULL,
  `domain` VARCHAR(45) NULL,
  `kingdom` VARCHAR(45) NULL,
  `phylum` VARCHAR(45) NULL,
  `class` VARCHAR(45) NULL,
  `order` VARCHAR(45) NULL,
  `family` VARCHAR(45) NULL,
  `genus` VARCHAR(45) NULL,
  `species` VARCHAR(45) NULL,
  `full` MEDIUMTEXT NOT NULL COMMENT '除了前面的标准的分类层次之外，在这里还有包含有非标准的分类层次的信息，使用json字符串存放这些物种分类信息',
  UNIQUE INDEX `organism_name_UNIQUE` (`organism_name` ASC),
  PRIMARY KEY (`uid`),
  UNIQUE INDEX `uid_UNIQUE` (`uid` ASC))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `UniProtKB`.`hash_table`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `UniProtKB`.`hash_table` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `UniProtKB`.`hash_table` (
  `uniprot_id` CHAR(32) NOT NULL COMMENT 'uniprot数据库编号首先会在这个表之中进行查找，得到自己唯一的哈希值结果，然后再根据这个哈希值去快速的查找其他的表之中的结果',
  `hash_code` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '每一个字符串形式的uniprot数据库编号都有一个唯一的哈希值编号',
  PRIMARY KEY (`uniprot_id`),
  UNIQUE INDEX `uniprot_id_UNIQUE` (`uniprot_id` ASC),
  UNIQUE INDEX `hash_code_UNIQUE` (`hash_code` ASC))
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `UniProtKB`.`seq_archive`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `UniProtKB`.`seq_archive` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `UniProtKB`.`seq_archive` (
  `hash_code` INT UNSIGNED NOT NULL,
  `uniprot_id` VARCHAR(45) NOT NULL COMMENT 'UniqueIdentifier Is the primary accession number of the UniProtKB entry.(对hash_code起校验用)',
  `entry_name` VARCHAR(45) NULL DEFAULT NULL COMMENT 'EntryName Is the entry name of the UniProtKB entry.',
  `organism_id` INT UNSIGNED NOT NULL COMMENT 'OrganismName Is the scientific name of the organism of the UniProtKB entry, this is the id reference to the organism_code table.',
  `organism_name` LONGTEXT NOT NULL COMMENT '对organism_id校验所使用的',
  `gn` VARCHAR(45) NULL DEFAULT NULL COMMENT 'GeneName Is the first gene name of the UniProtKB entry. If there Is no gene name, OrderedLocusName Or ORFname, the GN field Is Not listed.',
  `pe` VARCHAR(45) NULL DEFAULT NULL COMMENT 'ProteinExistence Is the numerical value describing the evidence for the existence of the protein.',
  `sv` VARCHAR(45) NULL DEFAULT NULL COMMENT 'SequenceVersion Is the version number of the sequence.',
  `prot_name` TINYTEXT NULL DEFAULT NULL COMMENT 'ProteinName Is the recommended name of the UniProtKB entry as annotated in the RecName field. For UniProtKB/TrEMBL entries without a RecName field, the SubName field Is used. In case of multiple SubNames, the first one Is used. The \'precursor\' attribute is excluded, \'Fragment\' is included with the name if applicable.',
  `length` INT(11) NULL DEFAULT NULL COMMENT 'length of the protein sequence',
  `sequence` TEXT NULL DEFAULT NULL COMMENT 'protein sequence',
  PRIMARY KEY (`hash_code`, `uniprot_id`),
  UNIQUE INDEX `uniprot_id_UNIQUE` (`uniprot_id` ASC),
  UNIQUE INDEX `hash_code_UNIQUE` (`hash_code` ASC),
  INDEX `seq_archive_organism_code_idx` (`organism_id` ASC),
  CONSTRAINT `seq_archive_organism_code`
    FOREIGN KEY (`organism_id`)
    REFERENCES `UniProtKB`.`organism_code` (`uid`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `seq_archive_uniprot_id_hash_code`
    FOREIGN KEY (`hash_code`)
    REFERENCES `UniProtKB`.`hash_table` (`hash_code`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

SHOW WARNINGS;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
