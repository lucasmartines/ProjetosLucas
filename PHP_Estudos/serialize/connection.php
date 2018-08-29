<?php
    $con = new mysqli("localhost","root","","server");

    if(!$con){
        die("fail connection" . mysqli_connect_error() ) ;
    }
