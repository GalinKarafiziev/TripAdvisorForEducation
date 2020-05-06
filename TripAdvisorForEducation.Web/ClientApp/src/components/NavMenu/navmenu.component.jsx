import React, { Component } from "react";
import { Link } from "react-router-dom";

import { ReactComponent as Logo } from "../../assets/EdTech.svg";

import "./navmenu.style.css";



export default class NavMenu extends Component {
    render() {
        return (
            <div className="header">
            <Link className="logo-container" to="/">
              <Logo className="logo" />
            </Link>
        
            <div className="options">
              <Link className="logo-container" to="/">
                <Logo className="logo" />
              </Link>
              <Link className="logo-container" to="/">
                <Logo className="logo" />
              </Link>
              <Link className="logo-container" to="/">
                <Logo className="logo" />
              </Link>
              <Link className="logo-container" to="/">
                <Logo className="logo" />
              </Link>
            </div>
          </div>
        )
    }
}

