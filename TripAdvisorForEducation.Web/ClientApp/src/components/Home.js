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
        var response = await fetch('categories/');
        var json = await response.json();

        //console.log(JSON.parse(json))

        return {}
    }

    componentWillMount() {
        this.getData().then(data => {
            //this.setState({ model: data })
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
