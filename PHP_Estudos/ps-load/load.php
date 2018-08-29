<?php

spl_autoload_register( 'autoloader' ); 


function autoloader($className){
    $path = '';
    include $path . $className.'.class.php';

}