<?php

function autoload( $class ){
    require "class/". $class . ".class.php";
}


spl_autoload_register("autoload");
