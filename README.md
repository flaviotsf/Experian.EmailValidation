#QAS Email Validation Library

This library provides basic code to use the QAS Email Validation Library.

##Overview

This library has JsonNet as a dependency for JSON Serialization / Deserialization.

In order to use it, you need to ensure you have a few keys ob your app / web.config

    
    <add key="Qas.EmailValidation.Endpoint" value="https://api.experianmarketingservices.com/query/EmailValidate/1.0/"/>
    <add key="Qas.EmailValidation.AuthToken" value="XXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"/>
    <add key="Qas.EmailValidation.Retry.Delay" value="5000" />
    <add key="Qas.EmailValidation.Retry.Count" value="5" />