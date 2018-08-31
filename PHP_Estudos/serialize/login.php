<?php 
    if ( isset ( $_COOKIE['logado'] ) )
    {
        if ( $_COOKIE['logado'] )
        {
            header("Location:index.php");
        }
    }


    if ( isset( $_POST['name'] ) && isset( $_POST['password']  ) ){
        
        $name =  $_POST['name'];
        $pass =  $_POST['password'];

        require "connection.php";

        $sql = "select NOME,SENHA from usuario where NOME='$name' and SENHA='$pass' ";
        $query = mysqli_query($con,$sql);
        if ( $query ){
            
            if( mysqli_num_rows($query) > 0 ){
                setcookie('logado',true);
                setcookie('nome',$name);
                header("Location:index.php");
            }
            else{
                echo "Erro ao logar a senha não está correta";
            }   

        }
        else{
            echo mysqli_error();
        }
    }

?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
    <style>
    *{
        font-family:"arial";
    }
        body{
            width:800px;
            background-color:#f1f1f1;
            margin:auto;
        }
        form{
           
            width:200px;
            background-color:#aaa;
            color:white;

            margin:auto;
            margin-top: 200px;
            padding:20px;
            border-radius: 20px;
        }
        input[type=submit]{
            padding:10px;
            
            margin:auto;
        }
    </style>
</head>
<body>

    <form action=" <?php echo htmlspecialchars($_SERVER["PHP_SELF"]) ?>" method="post">
        <h1 style="text-align:center"> Login </h1>
        <p> User </p>

        <input type="text" name = "name"  />
        <p> Password </p>
        <input type="password" name = "password"  />
        </br>
        </br>
        <a href="cadastro.php" >  Dont have a acoun t</a>
        <input type="submit" value = "Login"/>
    </form>

</body>
</html>