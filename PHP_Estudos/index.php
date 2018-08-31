<?php 
class TableRows extends RecursiveIteratorIterator { 
    function __construct($it) { 
        parent::__construct($it, self::LEAVES_ONLY); 
    }

    function current() {
        return "<td style='width:150px;border:1px solid black;'>" . parent::current(). "</td>";
    }

    function beginChildren() { 
        echo "<tr></br>"; 
    } 

    function endChildren() { 
        echo "</tr>" . "\n";
    } 
} 

    try{
        $connection = new PDO("mysql:host=localhost;dbname=test","root","");
       //

        $connection->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);

        echo "banco de dados acessado com sucesso";
    }
    catch(PDOException $ex){
        echo "algum erro: ".$ex;
    }

    try{
        $databanc_connection = new PDO("mysql:host=localhost;dbname=test","root","");
        $databanc_connection->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
        //$stmt = $databanc_connection->prepare("select number from tb");
        $stmt = $databanc_connection->prepare("select nome from doces");
        $stmt->execute();
        $result = $stmt->setFetchMode(PDO::FETCH_ASSOC); 
        foreach(new TableRows(new RecursiveArrayIterator($stmt->fetchAll())) as $k=>$v) { 
            echo $v;
        }
        $databanc_connection = null;
    }
    catch(PDOException $error){
        echo "erro : $error";

    }


?>