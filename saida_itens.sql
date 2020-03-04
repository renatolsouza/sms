SET @CODEMPRESA = 1;
SET @CODDEPARTAMENTO = 3; 
SET @DATAINICIAL = '2020-02-01';
SET @DATAFINAL = '2020-02-28';

SELECT S.CODEMPRESA, E.NOME AS NOMEEMPRESA, S.CODDEPARTAMENTO, D.NOME AS NOMEDEPARTAMENTO, S.CODSAIDA, 
DATE_FORMAT(S.DATAENTREGA, '%d/%m/%Y') AS DATASAIDA, S.CODUNIDADE, U.NOME AS NOMEUNIDADE, PE.SOLICITANTE,
S.NUMEROPEDIDO, SI.CODPRODUTO, P.NOME AS NOMEPRODUTO, SI.ENTREGUE AS QUANTIDADE 

FROM saida S
INNER JOIN empresa E ON S.CODEMPRESA = E.CODEMPRESA
INNER JOIN departamento D ON S.CODDEPARTAMENTO = D.CODDEPARTAMENTO
INNER JOIN unidade U ON S.CODUNIDADE = U.CODUNIDADE
INNER JOIN pedido PE ON S.NUMEROPEDIDO = PE.NUMEROPEDIDO
INNER JOIN saida_item SI ON S.CODSAIDA = SI.CODSAIDA
INNER JOIN produtos P ON SI.CODPRODUTO = P.CODPRODUTO

WHERE S.DATAENTREGA BETWEEN @DATAINICIAL AND @DATAFINAL
AND S.CODEMPRESA = @CODEMPRESA
AND S.CODDEPARTAMENTO = @CODDEPARTAMENTO

ORDER BY S.CODSAIDA