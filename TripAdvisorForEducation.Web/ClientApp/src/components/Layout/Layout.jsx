import React, { Component } from "react";
import { Container } from "reactstrap";
import NavMenu from "../NavMenu/navmenu.component";

export default class Layout extends Component {
  render() {
    return (
      <div>
        <NavMenu />
        <div>
          {this.props.children}
        </div>
      </div>
    );
  }
}
