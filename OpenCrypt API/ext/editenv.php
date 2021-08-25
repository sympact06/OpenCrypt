<?php
if($_GET['ADMIN_TOKEN'] == env('ADMIN_TOKEN')){
    $key = $_GET['key'];
    putenv("KEY="+$key);
