import React, { Children } from 'react';

function ErrorPage(Message){
    console.log(Message);
return(<div>{Message}</div>);
}

export default ErrorPage;