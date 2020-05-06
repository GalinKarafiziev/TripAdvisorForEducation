import React, { Component } from "react";
import { Container, Button, Row, Col } from "reactstrap";

import { ReactComponent as QuestionImg } from "../../assets/undraw_questions_75e01.svg";
import { ReactComponent as ConnectedImg } from "../../assets/undraw_connected_8wvi1.svg";
import { ReactComponent as TrackImg } from "../../assets/undraw_track_and_field.svg";
import { ReactComponent as WorldImg } from "../../assets/undraw_connected_world.svg";

import "./for_companies.style.css";

function ForCompanies(props) {
  return (
    <div>
      <FirstSection />
      <SecondSection />
      <ThirdSection />
    </div>

  );
}
export default ForCompanies;

function FirstSection() {
  return (
    // <div className="first-section">
    <Container className="first-section-outer" fluid={true}>
      <Container className="first-section-inner">
        <Row md="2">
          <Col>
            <div className="header-text">
              <h1>Make the right decision for your Startup company</h1>
              <Button className="btn-request" color="danger">
                Request demo
              </Button>
            </div>
          </Col>
          <Col className="first-section-img">
            <QuestionImg />
          </Col>
        </Row>
      </Container>
    </Container>
  );
}

function SecondSection() {
  return (
    <Container className="second-section-outer">
      <Row md="2">
        <Col className="second-section-inner">
          <h1>Why help Startups?</h1>
          <h2>Connect with the right customers</h2>
          <p>
            Many startups face the problem with inefficient user
            engagement.Edtech companies lose track of their real customers over
            time or try to solve a problem that does not exist which leads to
            product failure.
          </p>
        </Col>
        <Col className="second-section-img">
          <ConnectedImg />
        </Col>
      </Row>
    </Container>
  );
}

function ThirdSection() {
  return (
    <Container className="third-section-outer" fluid={true}>
      <Container className="third-section-inner">
        <Row md="2">
          <Col>
            <Container 
            className="third-section-inner-left">
              <TrackImg 
              className="third-section-inner-left-img" />
              <h2>Show early tracktion</h2>
              <p>
                Build confidence around your product and stay as close as
                possible with your current clients and users.
              </p>
            </Container>
          </Col>

          <Col>
            <Container 
            className="third-section-inner-right">
              <WorldImg />
              <h2>Scaling at the local level</h2>
              <p>
                Have a chance your product to be used in experiments within
                local universities
              </p>
            </Container>
          </Col>
        </Row>
      </Container>
    </Container>
  );
}
