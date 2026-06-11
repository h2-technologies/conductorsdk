# Conductor SDK for .NET
A dotnet native SDK for [conductor.is](https://conductor.is)

## Usage
The format of this SDK closely mirrors the node.js SDK. For example, to retrieve a transaction by ID:
- Node: 
```js 
    import Conductor from 'conductor-node';

    const conductor = new Conductor({
    apiKey: process.env['CONDUCTOR_SECRET_KEY'], // This is the default and can be omitted
    });

    const transaction = await conductor.qbd.transactions.retrieve('123ABC-1234567890', {
    conductorEndUserId: 'end_usr_1234567abcdefg',
    });

    console.log(transaction.account);
```

- C#:
```csharp
    using ConductorSdk;

    var conductor = new();

    var transaction = await conductor.Qbd.Transactions.Retrieve("123ABC-1234567890", "end_usr_1234567abcdefg");

    Console.WriteLine(transaction.Account);


```
## Disclaimer
*H2 Technologies is not affiliated with Conductor. This SDK is an independent project built by the community. For any questions or issues regarding this SDK, please open an issue in this repository. For any questions or issues regarding Conductor, please contact them directly.*