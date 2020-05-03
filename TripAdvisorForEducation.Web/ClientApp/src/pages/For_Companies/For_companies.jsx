import React from "react";
import { Container, Button, Row, Col } from "reactstrap";

import { ReactComponent as QuestionImg } from "../../assets/undraw_questions_75e01.svg";
import { ReactComponent as ConnectedImg } from "../../assets/undraw_connected_8wvi1.svg";
import { ReactComponent as TrackImg } from "../../assets/undraw_track_and_field.svg";
import { ReactComponent as WorldImg } from "../../assets/undraw_connected_world.svg";

import "./for_companies.style.css";

function ForCompanies(props) {
  return (
    <Container>
      <div className="first_container">
        <div className="first_content">
          <h1>Make the right decision for your Startup company</h1>
          <Button color="danger">Request demo</Button>
        </div>
        <div className="first_img">
          <QuestionImg />
        </div>
      </div>

      <div className="second_container">
        <div className="sec_content">
          <h1>Why help Startups?</h1>
          <h2>Connect with the right customers</h2>
          <p>
            Many startups face the problem with inefficient user
            engagement.Edtech companies lose track of their real customers over
            time or try to solve a problem that does not exist which leads to
            product failure.
          </p>
        </div>
        <div className="sec_img">
          <ConnectedImg />
        </div>
      </div>

      <Container className="">
        <Container className="">
          <TrackImg />
          <h2>Show early tracktion</h2>
          <p>
            Build confidence around your product and stay as close as possible
            with your current clients and users.
          </p>
        </Container>
        <Container className="">
          <WorldImg />
          <h2>Scaling at the local level</h2>
          <p>
            Have a chance your product to be used in experiments within local
            universities{" "}
          </p>
        </Container>
      </Container>
    </Container>
  );
}
export default ForCompanies;
