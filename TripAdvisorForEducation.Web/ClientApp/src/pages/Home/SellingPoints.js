import React from 'react';
import Grid from '@material-ui/core/Grid';
import { ReactComponent as StudySVG } from '../../assets/undraw_studying_s3l7.svg';
import { ReactComponent as TeachingSVG } from '../../assets/undraw_teaching.svg';
import { ReactComponent as TrustSVG } from '../../assets/undraw_trust.svg';
import { Typography } from '@material-ui/core';
import styles from '../../appStyles.module.css';

export default function Selling() {
  return (
    <Grid justify='center' container className={styles.sellingPointContainer}>
      <Grid direction='row' xs={9} item container justify='space-between'>
        <Grid item>
          <StudySVG />
          <Typography variant='h5' className={styles.cardTitle}>
            Learn your own way
          </Typography>
          <Typography variant='subtitle1' className={styles.cardSubtitle}>
            Find tools that gives you more flexible learning experiences and
            learn at your own pace.{' '}
          </Typography>
        </Grid>
        <Grid item>
          <TeachingSVG />
          <Typography variant='h5' className={styles.cardTitle}>
            Benefits for everyone
          </Typography>
          <Typography variant='subtitle1' className={styles.cardSubtitle}>
            By using technology in the classroom, both teachers and students can
            develop skills essential in modern workforce.{' '}
          </Typography>
        </Grid>
        <Grid item>
          <TrustSVG />
          <Typography variant='h5' className={styles.cardTitle}>
            Trusted products and reviewers{' '}
          </Typography>
          <Typography variant='subtitle1' className={styles.cardSubtitle}>
            We verify all start-up companies and their tools to ensure quaility
            is met. Each review comes from reliable person who used it.{' '}
          </Typography>
        </Grid>
      </Grid>
    </Grid>
  );
}
