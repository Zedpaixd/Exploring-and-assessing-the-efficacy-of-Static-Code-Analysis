<?php
// now TimeStamp returns the curent datetime in mySQL timestamp format
function nowTS() {
	$newdate = date("Y-m-d H:i:s");
	return $newdate;	
}

// extrdate Extracts mySQL timestamp into any date() parameter given
function extrdate($date,$parameters) {
	$strtotime = strtotime($date);
	$newdate = date($parameters,$strtotime);	
	return $newdate;
}

// since Calculates how many time past since given time
function since($time) {
$nowtime = nowTS();

	$nowyear = extrdate($nowtime,"Y");
	$nowmonth = extrdate($nowtime,"m");
	$nowday = extrdate($nowtime,"d");
	$nowhour = extrdate($nowtime,"H");
	$nowminut = extrdate($nowtime,"i");
	$nowsecond = extrdate($nowtime,"s");
			
	$timeyear = extrdate($time,"Y");
	$timemonth = extrdate($time,"m");
	$timeday = extrdate($time,"d");
	$timehour = extrdate($time,"H");
	$timeminut = extrdate($time,"i");
	$timesecond = extrdate($time,"s");
	
	$yearsince = $nowyear - $timeyear;
	$monthsince = $nowmonth - $timemonth;
	$daysince = $nowday - $timeday;
	$hoursince = $nowhour - $timehour;
	$minutsince = $nowminut - $timeminut;
	$secondsince = $nowsecond - $timesecond;
	
	/// Seconds Conf ///
	if ($nowsecond < $timesecond) {
		$secondsince = 60 + $nowsecond - $timesecond;
		$minusminut = TRUE;
	}
	/// Minuts Conf ///
	if ($minusminut == TRUE) {
		$nowminut = $nowminut - 1;
		
		if ($nowminut == $timeminut) {
			$minutsince =  $nowminut - $timeminut;
		}
	}
	if ($nowminut < $timeminut) {
		$minutsince =  60 + $nowminut - $timeminut;
		$minushour = TRUE;
	}	
	/// Hours Conf ///	
	if ($minushour == TRUE) {
		$nowhour = $nowhour - 1;
		
		if ($nowhour == $timehour) {
			$hoursince =  $nowhour - $timehour;
		}
	}
	if ($nowhour < $timehour) {
		$hoursince =  24 + $nowhour - $timehour;
		$minusday = TRUE;
	}	
	/// Days Conf ///	
	if ($minusday == TRUE) {
		$nowday = $nowday - 1;
		
		if ($nowday == $timeday) {
			$daysince =  $nowday - $timeday;
		}
	}
	if ($nowday < $timeday) {
		$daysince =  30 + $nowday - $timeday;
		$minusmonth = TRUE;
	}	
	/// Months Conf ///
	if ($minusmonth == TRUE) {
		$nowmonth = $nowmonth - 1;
		
		if ($nowmonth == $timemonth) {
			$monthsince =  $nowmonth - $timemonth;
		}
	}
	if ($nowmonth < $timemonth) {
		$monthsince =  12 + $nowmonth - $timemonth;
		$minusyear = TRUE;
	}	
	/// Years Conf ///
	if ($minusyear == TRUE) {
		$nowyear = $nowyear - 1;
		
		if ($nowyear == $timeyear) {
			$yearsince =  $nowyear - $timeyear;
		}
	}
	if ($nowyear < $timeyear) {
		$error = "The time you giving seems to be older then todays time";
	}	
	/////////////// end /////////////	
	if (!$error){
		if (!empty($yearsince)) {
		$time = "$yearsince<i>y</i> $monthsince<i>m</i>";	
		}
		if (empty($yearsince)) {
		$time = "$monthsince<i>m</i> $daysince<i>d</i>";	
		}
		if (empty($yearsince) && empty($monthsince)) {
		$time = "$daysince<i>d</i> $hoursince<i>h</i>";	
		}
		if (empty($yearsince) && empty($monthsince) && empty($daysince)) {
		$time = "$hoursince<u>h</u> $minutsince<u>m</u>";	
		}
		if (empty($yearsince) && empty($monthsince) && empty($daysince) && empty($hoursince)) {
		$time = "$minutsince<i>m</i> $secondsince<i>s</i>";	
		}
	return $time;
	}
	else echo $error;
}
?>