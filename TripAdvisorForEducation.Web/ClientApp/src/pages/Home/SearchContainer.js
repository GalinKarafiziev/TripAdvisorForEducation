import React from 'react';
import Grid from '@material-ui/core/Grid';
import { Typography } from '@material-ui/core';
import { ReactComponent as GraduationSVG } from '../../assets/undraw_Graduation_ktn0.svg';
import styles from '../../appStyles.module.css';

const SearchContainer = () => {
  return (
    <Grid
      container
      justify='center'
      alignItems='center'
      className={styles.searchContainer}
    >
      <Grid item xs={4} className={styles['home-header']}>
        <Typography variant='h3'>
          Find the right products for your academics needs
        </Typography>
        {/* <GraduationSVG></GraduationSVG> */}
        {/* <div className={styles.gradImage} /> */}
      </Grid>
      <GraduationSVG
        style={{
          marginLeft: '',
          zIndex: '0',
          position: 'absolute',
          opacity: '0.7',
        }}
      />
    </Grid>
  );
};

export default SearchContainer;
