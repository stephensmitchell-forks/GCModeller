﻿# helices
_namespace: [SMRUCC.genomics.Data.Regtransbase.StructureObjects](./index.md)_

helices - determine secondary structure

> 
>  CREATE TABLE `helices` (
>    `helix_guid` int(11) NOT NULL DEFAULT '0',
>    `pkg_guid` int(11) NOT NULL DEFAULT '0',
>    `art_guid` int(11) NOT NULL DEFAULT '0',
>    `name` varchar(50) DEFAULT NULL,
>    `fl_real_name` int(1) DEFAULT NULL,
>    `genome_guid` int(11) DEFAULT NULL,
>    `sec_struct_guid` int(11) DEFAULT NULL,
>    `pos_from1` int(11) DEFAULT NULL,
>    `pos_to1` int(11) DEFAULT NULL,
>    `pos_from2` int(11) DEFAULT NULL,
>    `pos_to2` int(11) DEFAULT NULL,
>    `descript` blob,
>    PRIMARY KEY (`helix_guid`),
>    KEY `FK_helices-pkg_guid` (`pkg_guid`),
>    KEY `FK_helices-art_guid` (`art_guid`),
>    KEY `FK_helices-genome_guid` (`genome_guid`),
>    KEY `FK_helices-sec_struct_guid` (`sec_struct_guid`),
>    CONSTRAINT `FK_helices-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
>    CONSTRAINT `FK_helices-genome_guid` FOREIGN KEY (`genome_guid`) REFERENCES `dict_genomes` (`genome_guid`),
>    CONSTRAINT `FK_helices-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`),
>    CONSTRAINT `FK_helices-sec_struct_guid` FOREIGN KEY (`sec_struct_guid`) REFERENCES `sec_structures` (`sec_struct_guid`),
>    CONSTRAINT `helices_ibfk_1` FOREIGN KEY (`sec_struct_guid`) REFERENCES `obj_name_genomes` (`obj_guid`)
>  ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
>  



### Properties

#### Guid
helix_guid
#### pos_from1
pos_from1, pos_to1, pos_from2, pos_to2 : helix coordinates relative to start of RNA secondary structure
#### sec_struc_guid
sec_struc_guid: id of the RNA secondary structure containing the helix
