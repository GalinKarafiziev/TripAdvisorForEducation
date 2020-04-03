import React, { Component } from 'react';

export class Home extends Component {
    constructor(props) {
        super(props);

        this.state = {
            model: {
                userId: '',
                description: '',
                website: '',
                userName: '',
                categories: '',
                reviews: ''
            }
        }
    }

    getData = async () => {
        var response = await fetch('company/1');
        var json = await response.json();

        console.log(JSON.parse(json))

        return JSON.parse(json)
    }

    componentWillMount() {
        this.getData().then(data => {
            this.setState({ model: data })
        })
    }

    render() {
        const { userName, description } = this.state.model;

        return (
            <div>
                <div>
                    Hello {userName}
                </div>
                <div>
                    Description {description}
                </div>
            </div>
        );
    }
}
