import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import clsx from "clsx";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardMedia from "@material-ui/core/CardMedia";
import CardContent from "@material-ui/core/CardContent";
import CardActions from "@material-ui/core/CardActions";
import Collapse from "@material-ui/core/Collapse";
import Avatar from "@material-ui/core/Avatar";
import IconButton from "@material-ui/core/IconButton";
import Typography from "@material-ui/core/Typography";
import { red } from "@material-ui/core/colors";
import FavoriteIcon from "@material-ui/icons/Favorite";
import ShareIcon from "@material-ui/icons/Share";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import MoreVertIcon from "@material-ui/icons/MoreVert";
import Button from "@material-ui/core/Button";
import { CardActionArea } from "@material-ui/core";
import { BorderAllRounded } from "@material-ui/icons";
import { Link, useRouteMatch } from "react-router-dom";

const useStyles = makeStyles((theme) => ({
  root: {
    width: 270,
    height: 340,
  },
  media: {
    height: 200,
    marginLeft: 10,
    marginRight: 10,
  },
}));

function BuildingCard({ building, bg }) {
  const classes = useStyles();
  const { Name, Id, NumberOfUnits } = building;
  const { path, url } = useRouteMatch();

  return (
    <CardActionArea component={Link} to={`${url}/${Id}`}>
      <Card className={classes.root} style={{ backgroundColor: bg }}>
        <CardHeader title={Name} subheader={Id} />
        <CardMedia
          className={classes.media}
          image="https://specials-images.forbesimg.com/dam/imageserve/947014356/960x0.jpg"
          title="apartment image"
        />
        <CardContent>
          <Typography variant="body2" color="textSecondary" component="p">
            <b>Number of Units : {NumberOfUnits}</b>
          </Typography>
        </CardContent>
      </Card>
    </CardActionArea>
  );
}

export default BuildingCard;
