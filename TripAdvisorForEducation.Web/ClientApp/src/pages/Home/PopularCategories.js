import React, { useState } from 'react';
import { Typography, Grid } from '@material-ui/core';
import ListItem from '@material-ui/core/ListItem';
import styles from '../../appStyles.module.css';

export default function PopularCategories() {
  //   const [categories, setCategories] = useState({ hits: [] });
  const elements = [
    'Assistance',
    'Feedback',
    'Communication',
    'Task Managment',
    'Schedule',
    'Presentation',
    'Peer Feedback',
  ];
  const elements2 = [
    'Documentation',
    'Interactive Video',
    'Grading',
    'Peer Reviews',
    'Plan Managmnet',
    'Learming management system',
  ];

  return (
    <Grid
      justify='center'
      item
      container
      className={styles['popular-categories-container']}
    >
      <Grid item justify='flex-start' xs={9} container alignItems='center'>
        <Grid item xs={12} style={{ paddingBottom: '40px' }}>
          <Typography variant='h3'>Popular Categories</Typography>
        </Grid>
        <Grid container justify='flex-start'>
          <Grid item xs={12} md={4}>
            {elements.map((value) => {
              return (
                <ListItem style={{ padding: '0px' }}>
                  <Typography variant='subtitle1'>{value}</Typography>
                </ListItem>
              );
            })}
          </Grid>
          <Grid item xs={12} md={4}>
            {elements2.map((value) => {
              return (
                <ListItem style={{ padding: '0px' }}>
                  <Typography variant='subtitle1'>{value}</Typography>
                </ListItem>
              );
            })}
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
}
