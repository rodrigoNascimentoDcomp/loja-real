CREATE DATABASE  IF NOT EXISTS `loja` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `loja`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: loja
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `boleto`
--

DROP TABLE IF EXISTS boleto;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE boleto (
  numero varchar(128) NOT NULL,
  UNIQUE KEY numero_UNIQUE (numero)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cartao_credito`
--

DROP TABLE IF EXISTS cartao_credito;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE cartao_credito (
  id int unsigned NOT NULL AUTO_INCREMENT,
  numero varchar(16) NOT NULL,
  titular varchar(45) NOT NULL,
  cpf bigint NOT NULL,
  `data` datetime NOT NULL,
  PRIMARY KEY (id),
  UNIQUE KEY numero_UNIQUE (numero)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `catalogo`
--

DROP TABLE IF EXISTS catalogo;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE catalogo (
  loja_cnpj bigint unsigned NOT NULL,
  produto_id int unsigned NOT NULL,
  preco decimal(10,0) NOT NULL,
  quantidade int unsigned NOT NULL,
  detalhes varchar(45) DEFAULT NULL,
  KEY fk_catalogo_loja_idx (loja_cnpj),
  KEY fk_catalogo_produto_idx (produto_id),
  CONSTRAINT fk_catalogo_loja FOREIGN KEY (loja_cnpj) REFERENCES loja (cnpj),
  CONSTRAINT fk_catalogo_produto FOREIGN KEY (produto_id) REFERENCES produto (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS categoria;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE categoria (
  id int unsigned NOT NULL AUTO_INCREMENT,
  nome varchar(45) NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `categoria_loja`
--

DROP TABLE IF EXISTS categoria_loja;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE categoria_loja (
  loja_cnpj bigint unsigned NOT NULL,
  cateogria_id int unsigned NOT NULL,
  KEY fk_categoria_loja_loja_idx (loja_cnpj),
  KEY fk_categoria_loja_categoria_idx (cateogria_id),
  CONSTRAINT fk_categoria_loja_categoria FOREIGN KEY (cateogria_id) REFERENCES categoria (id),
  CONSTRAINT fk_categoria_loja_loja FOREIGN KEY (loja_cnpj) REFERENCES loja (cnpj)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `categoria_produto`
--

DROP TABLE IF EXISTS categoria_produto;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE categoria_produto (
  categoria_id int unsigned NOT NULL,
  produto_id int unsigned NOT NULL,
  KEY fk_categoria_produto_idx (produto_id),
  KEY fk_produto_categoria_idx (categoria_id),
  CONSTRAINT fk_categoria_produto FOREIGN KEY (produto_id) REFERENCES produto (id),
  CONSTRAINT fk_produto_categoria FOREIGN KEY (categoria_id) REFERENCES categoria (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `compra`
--

DROP TABLE IF EXISTS compra;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE compra (
  id int unsigned NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  valor_total decimal(6,2) NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `compra_status`
--

DROP TABLE IF EXISTS compra_status;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE compra_status (
  compra_id int unsigned NOT NULL,
  status_id int unsigned NOT NULL,
  `data` datetime NOT NULL,
  KEY compra_id_idx (compra_id),
  KEY status_id_idx (status_id),
  CONSTRAINT compra_id FOREIGN KEY (compra_id) REFERENCES compra (id),
  CONSTRAINT status_id FOREIGN KEY (status_id) REFERENCES `status` (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `comprador`
--

DROP TABLE IF EXISTS comprador;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE comprador (
  cpf bigint unsigned NOT NULL,
  primeiro_nome varchar(45) NOT NULL,
  sobrenome varchar(45) NOT NULL,
  usuario_login varchar(45) NOT NULL,
  PRIMARY KEY (cpf),
  UNIQUE KEY usuario_login_UNIQUE (usuario_login),
  CONSTRAINT fk_comprador_usuario FOREIGN KEY (usuario_login) REFERENCES usuario (login)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `endereco`
--

DROP TABLE IF EXISTS endereco;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE endereco (
  id int unsigned NOT NULL AUTO_INCREMENT,
  cep int unsigned NOT NULL,
  rua varchar(45) NOT NULL,
  estado varchar(19) NOT NULL,
  bairro varchar(45) NOT NULL,
  numero int unsigned DEFAULT NULL,
  complemento varchar(45) DEFAULT NULL,
  nome varchar(45) DEFAULT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `formas_de_pagamento`
--

DROP TABLE IF EXISTS formas_de_pagamento;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE formas_de_pagamento (
  id int unsigned NOT NULL AUTO_INCREMENT,
  resposta int NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS item;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE item (
  numero int unsigned NOT NULL AUTO_INCREMENT,
  quantidade int unsigned NOT NULL,
  valor decimal(10,0) NOT NULL,
  compra_id int unsigned NOT NULL,
  PRIMARY KEY (numero),
  KEY fk_item_compra_idx (compra_id),
  CONSTRAINT fk_item_compra FOREIGN KEY (compra_id) REFERENCES compra (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `loja`
--

DROP TABLE IF EXISTS loja;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE loja (
  cnpj bigint unsigned NOT NULL,
  nome varchar(45) NOT NULL,
  numero_de_vendas int unsigned NOT NULL,
  usuario_login varchar(45) NOT NULL,
  PRIMARY KEY (cnpj),
  UNIQUE KEY usuario_login_UNIQUE (usuario_login),
  CONSTRAINT fk_loja_usuario FOREIGN KEY (usuario_login) REFERENCES usuario (login)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pagamento`
--

DROP TABLE IF EXISTS pagamento;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE pagamento (
  parcelas int unsigned NOT NULL,
  `status` enum('aprovado','negado','esperando_confirmacao') NOT NULL,
  valor decimal(6,2) NOT NULL,
  compra_id int unsigned NOT NULL,
  UNIQUE KEY compra_id_UNIQUE (compra_id),
  CONSTRAINT fk_pagamento_compra FOREIGN KEY (compra_id) REFERENCES compra (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pix`
--

DROP TABLE IF EXISTS pix;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE pix (
  qr_code varchar(45) NOT NULL,
  copia_e_cola varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `produto`
--

DROP TABLE IF EXISTS produto;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE produto (
  id int unsigned NOT NULL AUTO_INCREMENT,
  nome varchar(45) NOT NULL,
  especificacao varchar(45) DEFAULT NULL,
  `status` enum('venda','cadastro','cancelado') NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `promocao`
--

DROP TABLE IF EXISTS promocao;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE promocao (
  numero int unsigned NOT NULL AUTO_INCREMENT,
  tipo enum('compra','item') NOT NULL,
  data_inicio datetime NOT NULL,
  data_fim datetime NOT NULL,
  loja_cnpj bigint unsigned NOT NULL,
  PRIMARY KEY (numero),
  KEY fk_promocao_loja_idx (loja_cnpj),
  CONSTRAINT fk_promocao_loja FOREIGN KEY (loja_cnpj) REFERENCES loja (cnpj)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `solicita_cadastro`
--

DROP TABLE IF EXISTS solicita_cadastro;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE solicita_cadastro (
  `data` datetime NOT NULL,
  `status` enum('cadastrado','em_analise','aprovado','negado') NOT NULL,
  observacao varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS status;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  id int unsigned NOT NULL AUTO_INCREMENT,
  descricao varchar(45) NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `status_item`
--

DROP TABLE IF EXISTS status_item;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE status_item (
  id int unsigned NOT NULL AUTO_INCREMENT,
  descricao varchar(45) NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS usuario;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE usuario (
  login varchar(45) NOT NULL,
  senha varchar(32) NOT NULL,
  `status` enum('ativo','inativo','bloqueado','cancelado') NOT NULL,
  PRIMARY KEY (login)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usuario_sistema`
--

DROP TABLE IF EXISTS usuario_sistema;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE usuario_sistema (
  login varchar(45) NOT NULL,
  nome varchar(45) NOT NULL,
  senha varchar(32) NOT NULL,
  PRIMARY KEY (login)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usuario_sistema_categoria`
--

DROP TABLE IF EXISTS usuario_sistema_categoria;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE usuario_sistema_categoria (
  usuario_sistema_login varchar(45) NOT NULL,
  categoria_id int unsigned NOT NULL,
  `data` datetime NOT NULL,
  operacao enum('inserir','remover','atualizar') NOT NULL,
  KEY fk_usuario_sistema_categoria_login_idx (usuario_sistema_login),
  KEY fk_usuario_sistema_categoria_id_idx (categoria_id),
  CONSTRAINT fk_usuario_sistema_categoria_id FOREIGN KEY (categoria_id) REFERENCES categoria (id),
  CONSTRAINT fk_usuario_sistema_categoria_login FOREIGN KEY (usuario_sistema_login) REFERENCES usuario_sistema (login)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usuario_usuario_sistema`
--

DROP TABLE IF EXISTS usuario_usuario_sistema;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE usuario_usuario_sistema (
  usuario_login varchar(45) NOT NULL,
  usuario_sistema_login varchar(45) NOT NULL,
  `data` datetime NOT NULL,
  operacao enum('inserir','remover','atualizar') NOT NULL,
  KEY usuario_login_idx (usuario_login),
  KEY usuario_sistema_login_idx (usuario_sistema_login),
  CONSTRAINT usuario_login FOREIGN KEY (usuario_login) REFERENCES usuario (login),
  CONSTRAINT usuario_sistema_login FOREIGN KEY (usuario_sistema_login) REFERENCES usuario_sistema (login)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed
