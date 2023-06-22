// TODO: implement class TimerService from the ITimerService interface.
//       Service have to be just wrapper on System Timers.

using CoolParking.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Timers;

public class TimerService: ITimerService
{

    private Timer timer;

    public event ElapsedEventHandler Elapsed;
    
    public double Interval { get; set; }

    public TimerService(double interval)
    {
        
        Interval = interval;
        timer = new Timer(Interval);
        timer.AutoReset = true;
        timer.Enabled = true;
        timer.Elapsed += Timer_Elapsed;
    }

    public void Start()
    {

        timer.Start();
    }

    public void Stop()
    {
        timer.Stop();
    }

    public void Dispose()
    {
        timer.Dispose();
    }
    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {

        this.Elapsed?.Invoke(this, e);
    }






}
