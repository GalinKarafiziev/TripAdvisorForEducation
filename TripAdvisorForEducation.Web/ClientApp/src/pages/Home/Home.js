import React from 'react';
import SearchContainer from './SearchContainer';
import SellingPoints from './SellingPoints';
import PopularCategories from './PopularCategories';
const Home = () => {
  return (
    <div >
      <SearchContainer />
      <SellingPoints />
      <PopularCategories />
    </div>
  );
};

export default Home;
