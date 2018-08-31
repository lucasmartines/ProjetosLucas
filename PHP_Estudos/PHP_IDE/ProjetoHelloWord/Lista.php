<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

session_start();

if( isset ( $_GET['show'] ) ){
    echo  ListaController::showValuesTable();
}
 
if (!isset($_SESSION['lista']) ){
    $_SESSION['lista'] = array();
    $_SESSION['id_conter'] = 0;
  
}

class ListaController{
    
    
   
    
    public static function addListaValues($nomeElemento,$texto){
   
        $obj = new stdclass;
        $obj->nome = $nomeElemento;
        $obj->id = $_SESSION['id_conter'];
        $obj->texto = $texto;
        if (!$_SESSION['lista'] ){
            $_SESSION['lista'] = array();
            $_SESSION['id_conter'] = 0;
        }
        
        # IF A OBJECT WAS NOT ADDED YET SO ADD HE
        if( !array_key_exists( $_SESSION['id_conter'] , $_SESSION['lista'] )){
            
            array_push( $_SESSION['lista'] , $obj );
          
        }
        $_SESSION['id_conter'] ++  ;
        
    }
    public static function showValuesTable(){
        /*PRINT A TABLE*/
        if ( is_array(  $_SESSION['lista']  ) )
        {
            $total = "<tr> <th> Id </th> <th> Nome </th> <th> Texto </th> </tr>";
            
            foreach( $_SESSION['lista'] as $id => $value ){
              
                $refatoredID = $id;#START ID data by 1
                
                $total = $total .
               
                "<tr> <td>". $refatoredID ." </td> <td> $value->nome </td> <td> $value->texto  </td> </tr>"
                ;
            }
            
            return trim( $total );
            
        }
    }
    public static function pop(){
        
        if(  isset( $_SESSION['lista'] ) )
        {
          if( is_array($_SESSION['lista'] ) )
         {
              array_pop( $_SESSION['lista'] );
         }
        }
    }
    public static function deletListValue($id){
        
        if(array_key_exists ( $id , $_SESSION['lista']) )
        {
             unset( $_SESSION['lista'][$id] );
        }
    }
    public static function startList(){
        $_SESSION['lista'] = array();
    }
    
    public static function getListQuantity(){
       return count ( $_SESSION['lista'] ) ;
    }
}