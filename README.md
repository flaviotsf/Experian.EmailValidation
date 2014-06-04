#Experian Email Validation Library

This library provides basic code to use the QAS Email Validation Library.

##Overview

This library has JsonNet as a dependency for JSON Serialization / Deserialization.

In order to use it, you need to ensure you have a few keys ob your app / web.config

    
    <add key="Experian.EmailValidation.Endpoint" value="https://api.experianmarketingservices.com/query/EmailValidate/1.0/"/>
    <add key="Experian.EmailValidation.AuthToken" value="XXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"/>
    <add key="Experian.EmailValidation.Retry.Delay" value="5000" />
    <add key="Experian.EmailValidation.Retry.Count" value="5" />

To call the library simply use

     EmailValidation.ValidateEmail("testingaccount@gmail.com");
     
     
A property IsValidEmail was added that return true/false depending on the QAS Certainty Status. It will return true for Valid and Unkown emails.
