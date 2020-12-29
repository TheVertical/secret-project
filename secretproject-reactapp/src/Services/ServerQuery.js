import React from 'react'
import Cookies from 'js-cookie'

export async function GetSettings() {
  // const sessionId = Cookies.get('.AspNetCore.Session');
  // if(sessionId == undefined)
  //   Cookies.set('.AspNetCore.Session','CfDJ8FUTAXDxQStCvkitdVjF5cfs4yt%2B8QU6HHaSySdwkA4hZw%2BO1oeBG7fTMQZqwRt3y%2B5Grdmj%2BapTdltEXaV5XQEX6wYvQouxcbQoyz2aTKUD0SrVIcvCitPy8nY20ynhT64sQ%2BrwQIM2Py9Yi66%2FDadjWU9koZaxdAPvE7b15KTx');
  const responce = await MakeSimpleServerQuery('GET', '/settings');
  return responce;
}
export async function MakeSimpleServerQuery(httpMethod, url) {
  // const server = "http://secrethost.azurewebsites.net";
  const server = "http://localhost:50258";
  switch (httpMethod) {
    case 'GET': break;
    case 'POST': break;
    default: throw 'Methodd of Http is uncorrect. It was ' + httpMethod + '!';
  }
  const json = {
    success: false, data: {}
  };
  try {
    let responce = await fetch(server + url,
      {
        method: httpMethod,
        mode:'cors',
        credentials: 'include'
      })
      // .then((data) => { console.debug(data) });
    json.success = true;
    return json;
  }
  catch (error) {
    console.error('error on:' + server + url + '\n' + 'Error message:' + error, json.data);
  }
  return json;
}
export async function MakeServerQuery(httpMethod, url) {
  // const server = "http://secrethost.azurewebsites.net";
  const server = "http://localhost:50258";

  switch (httpMethod) {
    case 'GET': break;
    case 'POST': break;
    default: throw 'Methodd of Http is uncorrect. It was ' + httpMethod + '!';
  }
  const json = {
    success: false, data: {}
  };
  try {
    let responce = await fetch(server + url,
      {
        method: httpMethod,
        mode:'cors',
        credentials: 'include'
      });
    json.data = await responce.json();
    console.log('success on ' + server + url, json.data);
    json.success = true;
    return json;
  }
  catch (error) {
    console.error('error on:' + server + url + '\n' + 'Error message:' + error, json.data);
  }
  return json;
}
export async function MakeQuery(method, url, body) {

}

