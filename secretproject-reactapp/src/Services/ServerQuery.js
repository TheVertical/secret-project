import React from 'react'

class ServerQuery extends React.Component{
  constructor() {
    this.server = "https://secrethost.azurewebsites.net";
  }

  async Make(httpMethod, url) {
    switch (httpMethod) {
      case 'GET': break;
      case 'POST': break;
      default: throw 'Methodd of Http is uncorrect. It was ' + httpMethod + '!';
    }
    const json = {
      success: false, data: {}
    };
    try {
      const responce = await fetch(this.server + url,
        {
          method: httpMethod
        });
      json.data = await responce.json();
      console.log('success on ' + this.server + url, json.data);
      json.success = true;
      return json;
    }
    catch (error) {
      console.error('error on' + this.server + url + '\n' + 'Error message' + error, json.data);
    }
    return json;
  }
  Make(method, url, body) {

  }
}

export async function MakeServerQuery(httpMethod, url) {
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

