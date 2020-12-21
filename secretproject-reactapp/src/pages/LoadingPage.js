import React from 'react'
import Spinner from 'react-bootstrap/Spinner'
import "./LoadingPage.css"
import { css } from "@emotion/core";
import ClipLoader from "react-spinners/ClipLoader";
// import ProductCardArray from './../hoCont/ProductCardArray'

class LoadingPage extends React.Component {

    constructor() {
        super();
        this.state = {}
    }

    render() {
        return (
            <div className="LoadingPage_GlobalStyle">
        <div className="sweet-loading">
        <ClipLoader
          size={50}
          color={"#123abc"}
          loading={this.props.loading}
        />
      </div>
            </div>
        )
    }

}
export default LoadingPage