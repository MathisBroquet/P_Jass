-- *********************************************
-- * SQL MySQL generation                      
-- *--------------------------------------------
-- * DB-MAIN version: 11.0.2              
-- * Generator date: Sep 14 2021              
-- * Generation date: Wed May 25 15:06:58 2022 
-- * LUN file: C:\Users\damloup\Desktop\P_Jass\Documentation\BaseDeDonnees\P_Jass.lun 
-- * Schema: db_P_Jass/1 
-- ********************************************* 


-- Database Section
-- ________________ 

create database db_P_Jass;
use db_P_Jass;


-- Tables Section
-- _____________ 

create table t_game (
     idGame bigint not null auto_increment,
     gamName varchar(50) not null,
     constraint ID_t_game_ID primary key (idGame));

create table t_play (
     idGame bigint not null,
     idUser bigint not null,
     constraint ID_t_play_ID primary key (idUser, idGame));

create table t_user (
     idUser bigint not null auto_increment,
     useName varchar(50) not null,
     usePassword varchar(50) not null,
     constraint ID_t_user_ID primary key (idUser));


-- Constraints Section
-- ___________________ 

alter table t_play add constraint FKt_p_t_u
     foreign key (idUser)
     references t_user (idUser);

alter table t_play add constraint FKt_p_t_g_FK
     foreign key (idGame)
     references t_game (idGame);


-- Index Section
-- _____________ 

create unique index ID_t_game_IND
     on t_game (idGame);

create unique index ID_t_play_IND
     on t_play (idUser, idGame);

create index FKt_p_t_g_IND
     on t_play (idGame);

create unique index ID_t_user_IND
     on t_user (idUser);

