<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 * 
 */
require 'Lista.php';

if( isset( $_GET['action'] ) ) 
{
    if($_GET['action'] == 'pop'){
         
        ListaController::pop();
        print ( ListaController::showValuesTable() );
        
         
    }
    if($_GET['action'] == 'delete'){
         
        ListaController::deletListValue($_GET['deleteNumber']);
        print ( ListaController::showValuesTable() );
        
         
    }
    if($_GET['action'] == 'show'){
    
        print ( ListaController::showValuesTable() );
        

    }
    
    if($_GET['action'] == 'reset'){
        session_destroy();
        echo "reset";
        
    }
    if($_GET['action'] == 'insert'){
        $nome = $_GET['nome'];
        $desc = $_GET['descricao'];
       
        
       
        ListaController::addListaValues(  $nome , $desc  ) ;
        print ( ListaController::showValuesTable() );
        

    }
    if($_GET['action'] == 'remove'){
        ListaController::deletListValue($_GET['remove-id']) ;

    }
    
}



